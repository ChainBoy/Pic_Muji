using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;


namespace TaoBao_Pic_Info
{
    public delegate void FlushClient();//代理
    public partial class MujiMainForm : Form
    {
        private const string SETTING_PATH = ".s";
        private static bool PASS = false;
        private static string PIC_URL_START = "http://img.muji.net/img/item/";
        private static string PIC_URL_END = "_400.jpg";
        private static string TEMPLATE_TEXT = "";
        private static string TEMPLATE_PATH = "template.csv";
        private static string TEMPLATE_REPLACE = "#U#";
        private static string RESULT_PATH = "result";
        private static string RESULT_SUFFIX = ".csv";
        private static string RESULT_SPARE_SUFFIX = ".csv";
        private static string ERROR_URL_PATH = "failed.txt";
        private Thread THREAD_SPIDER = null;

        private static string STATUS_REG = "尚未注册";
        private static int STATUS_SPIDER_VALUE = 0;
        private static string STATUS_TEXT = "";

        Comm comm = new Comm();
        ComputerCode code = new ComputerCode();

        public MujiMainForm()
        {
            InitializeComponent();
        }
        private void btn_create_com_Click(object sender, EventArgs e)
        {
            string user = this.tbx_user.Text.Trim();
            if (user.Length < 5)
            {
                MessageBox.Show("用户名不能小于5位！");
                return;
            }
            string com = code.getCom(user);
            this.tbx_com.Text = com;

        }

        private void btn_create_reg_Click(object sender, EventArgs e)
        {
            string com = this.tbx_com.Text.Trim();
            string reg = code.getReg(com);
            this.tbx_reg.Text = reg;
        }

        private void btn_check_reg_Click(object sender, EventArgs e)
        {
            if (this.tbx_reg.Text.Trim().Length < 10)
            {
                MessageBox.Show("注册码长度不正确，请重新确认并验证，如有问题请联系[张志鹏]。");
                return;
            }
            if (reg_user())
            {
                MessageBox.Show("恭喜你，注册成功！请妥善保管密钥！");
                this.tab_main.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("注册失败，请重新尝试，或者联系[张志鹏]。");
            }
        }

        /// <summary>
        /// 验证帐号、注册码、机器码
        /// </summary>
        /// <returns></returns>
        private bool reg_user()
        {
            bool result = false;
            string user = this.tbx_user.Text.Trim();
            string com = code.getCom(user);
            string reg = code.getReg(com);
            if (reg == this.tbx_reg.Text.Trim())
            {
                result = true;
                PASS = true;
                dump_info();
            }
            else
            {
                PASS = false;
                result = false;
            }
            return result;
        }

        private void MujiMainForm_Load(object sender, EventArgs e)
        {
            init();
        }

        private void tool_loginon_Click(object sender, EventArgs e)
        {
            show();
        }

        private void tool_spider_Click(object sender, EventArgs e)
        {
            this.tab_main.SelectedIndex = 0;
            //todo:暂时直接跳转抓取页，完善后必须验证是否注册。
            //show();
        }

        private void tool_exit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void init()
        {
            load_template();
            check_result_path();
            load_info();
            show();
        }
        private void show()
        {
            if (PASS)
            {
                this.tab_main.SelectedIndex = 0;
            }
            else
            {
                this.tab_main.SelectedIndex = 1;
            }
        }
        /// <summary> 加载模版
        /// 
        /// </summary>
        private void load_template()
        {
            try
            {
                using (StreamReader sr = new StreamReader(TEMPLATE_PATH, System.Text.Encoding.Default))
                {
                    TEMPLATE_TEXT = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            { }
            catch (DirectoryNotFoundException)
            { }
            catch (IOException)
            { }
            if (TEMPLATE_TEXT.Length <= 0)
            {
                TEMPLATE_TEXT = TEMPLATE_REPLACE;
                RESULT_SUFFIX = RESULT_SPARE_SUFFIX;
            }
        }


        /// <summary> 检查结果目录
        /// 
        /// </summary>
        private void check_result_path()
        {
            DirectoryInfo di = new DirectoryInfo(RESULT_PATH);
            if (!di.Exists)
            {
                di.Create();
            }
        }

        private void load_info()
        {
            Dictionary<string, string> Info = new Dictionary<string, string>();
            //comm.dump_pick(SETTING_PATH, Info);
            comm.load_pick(SETTING_PATH, out Info);
            string user = "";
            string com = "";
            string reg = "";
            Info.TryGetValue("user", out user);
            Info.TryGetValue("com", out com);
            Info.TryGetValue("reg", out reg);
            this.tbx_user.Text = user;
            this.tbx_com.Text = com;
            this.tbx_reg.Text = reg;
            reg_user();
        }

        private void dump_info()
        {
            Dictionary<string, string> Info = new Dictionary<string, string>();
            Info["user"] = this.tbx_user.Text.Trim();
            Info["com"] = this.tbx_com.Text.Trim();
            Info["reg"] = this.tbx_reg.Text.Trim();
            comm.dump_pick(SETTING_PATH, Info);
        }

        private void btn_spider_Click(object sender, EventArgs e)
        {
            THREAD_SPIDER = new Thread(spider_work);
            THREAD_SPIDER.IsBackground = true;
            THREAD_SPIDER.Start();
            //spider_work();
        }
        /// <summary> 开始爬取信息
        /// 
        /// </summary>
        private void spider_work()
        {
            List<string> urls = get_input_urls();
            string styleHtml = this.rtbx_style.Text;
            string sayHtml = this.rtbx_say.Text;
            if (urls.Count > 0)
            {
                for (int i = 0; i < urls.Count; i++)
                {
                    work_by_url(urls[i], sayHtml, styleHtml);
                }
            }
            else
            {
                THREAD_SPIDER.Abort();
                return;
            }
            THREAD_SPIDER.Abort();
        }

        /// <summary>抓取单个url，组装成div大标签(包含style)可以用于处理csv
        /// 
        /// </summary>
        /// <param name="url"></param>
        private void work_by_url(string url, string sayHtml, string styleHtml)
        {
            String con = comm.Request_string(url);
            List<string> color_pic_urls = new List<string>();
            get_color_pic_urls(con, out color_pic_urls);

            List<string> big_pic_urls = new List<string>();
            get_big_pic_urls(con, out big_pic_urls);

            string colorPicHtml = get_pic_html(color_pic_urls, "colorPic");
            string bigPicHtml = get_pic_html(big_pic_urls, "bigPic");

            List<string> try_pic_tags = new List<string>();
            get_try_pic_tags(con, out try_pic_tags);
            string tryPicHtml = get_try_pic_html(try_pic_tags, "tryPic");

            string sizeInfoHtml = "";
            get_size_info(con, out sizeInfoHtml);

            string shopInfoHtml = "";
            get_shop_info(con, out shopInfoHtml);

            get_say_info(ref sayHtml, url);
            string html = create_html_by_all_div(styleHtml, colorPicHtml, bigPicHtml, tryPicHtml, sizeInfoHtml, shopInfoHtml, sayHtml);

            string shop_id = "";
            if (html != "")
            {
                get_shop_id_by_url(url, out shop_id);
            }
            else
            {
                save_failed_url(url);
            }
            save_result(html, shop_id);
            string img_url = "";
            if (color_pic_urls.Count > 0)
            {
                img_url = color_pic_urls[0];
            }
            else if (big_pic_urls.Count > 0)
            {
                img_url = big_pic_urls[0];
            }
            if (img_url != "")
            {
                save_img_by_url(img_url, shop_id);
            }
        }

        private void save_img_by_url(string url, string shop_id)
        {
            byte[] img_b = comm.Request_bytes(url);
            //this.pictureBox1.Image = comm.bytes_to_image(img_b);
            comm.save_image_by_list_byte(img_b, RESULT_PATH + "/" + shop_id + ".jpg");
        }
        /// <summary> 根据URL获取商品Id，不存在则设置为时间戳:yyyyMMddHHmmssffff
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="shop_id"></param>
        private void get_shop_id_by_url(string url, out string shop_id)
        {
            shop_id = "";
            MatchCollection match_nid = Regex.Matches(url, @"http://.+?muji.net/.+?(\d+)", RegexOptions.Singleline);
            if (match_nid.Count > 0)
            {
                shop_id = match_nid[0].Groups[1].Value;
            }
            if (shop_id == "")
            {
                shop_id = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
        }

        /// <summary> 保存失败链接
        /// 
        /// </summary>
        /// <param name="url"></param>
        private void save_failed_url(string url)
        {
            using (StreamWriter sw = new StreamWriter(ERROR_URL_PATH, true))
            {
                sw.WriteLine(url);
            }
        }

        /// <summary>保存csv
        /// 
        /// </summary>
        /// <param name="html"></param>
        private void save_result(string html, string shop_id)
        {
            string csv_content = create_csv_by_html(html).ToString();
            check_result_path();
            using (StreamWriter sw = new StreamWriter(RESULT_PATH + "/" + shop_id + RESULT_SUFFIX, false, Encoding.Default))
            {
                sw.Write(csv_content);
            }

        }

        /// <summary>根据html和csv模版生成csv
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string create_csv_by_html(string html)
        {
            string result = "";
            //html = Regex.Replace(html, "\n|\r\n", "");
            if (RESULT_SUFFIX == ".csv")
            {
                html = Regex.Replace(html, "\"", "\"\"");
                result = Regex.Replace(TEMPLATE_TEXT, TEMPLATE_REPLACE, "\"" + html + "\"");
            }
            else
            {
                result = Regex.Replace(TEMPLATE_TEXT, TEMPLATE_REPLACE, html);
            }
            return result;
        }

        /// <summary> 根据现有 div tag，组装成最终要保存的div
        /// </summary>
        /// <param name="styleHtml"></param>
        /// <param name="colorPicHtml"></param>
        /// <param name="bigPicHtml"></param>
        /// <param name="tryPicHtml"></param>
        /// <param name="sizeInfoHtml"></param>
        /// <param name="shopInfoHtml"></param>
        /// <param name="sayHtml"></param>
        /// <returns></returns>
        private string create_html_by_all_div(string styleHtml, string colorPicHtml, string bigPicHtml, string tryPicHtml, string sizeInfoHtml, string shopInfoHtml, string sayHtml)
        {
            string divHtml = "<div style=\"width: 520px;\">" + styleHtml + colorPicHtml + bigPicHtml + tryPicHtml + sizeInfoHtml + shopInfoHtml + sayHtml + "</div>";
            return divHtml;
        }

        /// <summary> 获取用户输入的url队列
        /// </summary>
        /// <returns></returns>
        private List<string> get_input_urls()
        {
            List<string> result = new List<string>();
            string url_str = this.tbx_urls.Text.Trim();
            if (url_str.Length < 10)
            {
                MessageBox.Show("网址过短或者网址为空，请重新输入网址。");
            }
            else
            {
                MatchCollection match_nid = Regex.Matches(url_str, @"http://.+?muji.net/.+?\d+", RegexOptions.Singleline);
                if (match_nid.Count < 1)
                {
                    MessageBox.Show("请检查网址是否正确，网址域名是否为http://www.muji.net, 商品ID是否输入正确.");
                }
                else
                {
                    for (int i = 0; i < match_nid.Count; i++)
                    {
                        result.Add(match_nid[i].Groups[0].Value);
                    }
                }
            }
            return result;
        }

        /// <summary> 拼接图片html
        /// 
        /// </summary>
        /// <param name="pic_urls"></param>
        /// <param name="tag_id">div id</param>
        /// <returns></returns>
        private string get_pic_html(List<string> pic_urls, string tag_id = "colorPic")
        {
            string imgs_html = "<div id=\"" + tag_id + "\" class=\"section\">";
            for (int i = 0; i < pic_urls.Count; i++)
            {
                imgs_html += "<img src=\"" + pic_urls[i] + "\" width=\"400\" height=\"400\" >";
            }
            imgs_html += "</div>";
            return imgs_html;
        }

        /// <summary>获取试穿图片的html
        /// 
        /// </summary>
        /// <param name="try_pic_tags">img tag</param>
        /// <param name="tag_id">div id</param>
        /// <returns></returns>
        private string get_try_pic_html(List<string> try_pic_tags, string tag_id = "tryPic")
        {
            string imgs_html = "<div id=\"" + tag_id + "\" class=\"section\">";
            for (int i = 0; i < try_pic_tags.Count; i++)
            {
                imgs_html += try_pic_tags[i];
            }
            imgs_html += "</div>";
            return imgs_html;
        }

        /// <summary> 颜色图片
        /// </summary>
        /// <param name="con"></param>
        /// <param name="color_pic_urls"></param>
        private void get_color_pic_urls(string con, out List<string> color_pic_urls)
        {
            string url = "";
            color_pic_urls = new List<string>();
            MatchCollection match_color = Regex.Matches(con, @"colorPictureOptions.+?picturemap(.+?)}};", RegexOptions.Singleline);
            if (match_color.Count > 0)
            {
                string colors = match_color[0].Groups[1].Value;
                MatchCollection match_id = Regex.Matches(colors, "\"(\\d+)\"", RegexOptions.Singleline);
                for (int i = 0; i < match_id.Count; i++)
                {
                    string id = match_id[i].Groups[1].Value;
                    url = PIC_URL_START + id + PIC_URL_END;
                    color_pic_urls.Add(url);
                }
            }
        }

        /// <summary> 常规预览大图
        /// </summary>
        /// <param name="con"></param>
        /// <param name="big_pic_urls"></param>
        private void get_big_pic_urls(string con, out List<string> big_pic_urls)
        {
            string url = "";
            big_pic_urls = new List<string>();
            MatchCollection match_color = Regex.Matches(con, @"relatedPictureOptions .+?picturemap(.+?)}};", RegexOptions.Singleline);
            if (match_color.Count > 0)
            {
                string colors = match_color[0].Groups[1].Value;
                MatchCollection match_id = Regex.Matches(colors, @"/(\d+_\d+)_\d+", RegexOptions.Singleline);
                for (int i = 0; i < match_id.Count; i++)
                {
                    string id = match_id[i].Groups[1].Value;
                    url = PIC_URL_START + id + PIC_URL_END;
                    big_pic_urls.Add(url);
                }
            }
        }

        /// <summary> 获取大小说明
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sizeInfoHtml"></param>
        private void get_size_info(string con, out string sizeInfoHtml)
        {
            sizeInfoHtml = "";
            MatchCollection match_color = Regex.Matches(con, "<div id=\"sizeList.+?#sizeList -->", RegexOptions.Singleline);
            if (match_color.Count > 0)
            {
                sizeInfoHtml = match_color[0].Value;
            }
        }

        /// <summary> 获取产品说明
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="size_info"></param>
        private void get_shop_info(string con, out string shopInfoHtml)
        {
            shopInfoHtml = "";
            MatchCollection match_color = Regex.Matches(con, "<div id=\"spec.+?#spec -->", RegexOptions.Singleline);
            if (match_color.Count > 0)
            {
                shopInfoHtml = match_color[0].Value;
            }
        }

        /// <summary> 获取试穿图片img tag.
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="size_info"></param>
        private void get_try_pic_tags(string con, out List<string> try_pic_tags)
        {
            try_pic_tags = new List<string>();
            MatchCollection match_color = Regex.Matches(con, "figure.+?(<img.+?)</figure", RegexOptions.Singleline);
            for (int i = 0; i < match_color.Count; i++)
            {
                try_pic_tags.Add(match_color[i].Groups[1].Value);
            }
        }

        private void get_say_info(ref string sayHtml, string url)
        {
            sayHtml = "<div id=\"say\" class=\"section\"> <p class=\"MsoNormal\"> <span> " + sayHtml + " </span></p> <p> <span lang=\"EN-US\"><font color=\"#ffffff\">" + url + "</font></span></p></div>";
        }

        /// <summary>设置状态栏 登录信息
        /// 
        /// </summary>
        private void set_tool_status_reg()
        {
 
        }
        private void set_tool_status_spider()
        {
            if (this.tool_status_probar.Control.InvokeRequired)
            {
                FlushClient fc = new FlushClient(set_tool_status_spider);
                this.Invoke(fc);
            }
            else
            {
                this.tool_status_spider.Text = "";
            }
        }
        private void set_tool_probar()
        {
            if (this.tool_status_probar.Control.InvokeRequired)
            {
                FlushClient fc = new FlushClient(set_tool_probar);
                this.Invoke(fc);
            }
            else
            {
                this.tool_status_probar.Value = 1;
            }
        }
        private void set_tool_status_text()
        {
            if (this.tool_status_probar.Control.InvokeRequired)
            {
                FlushClient fc = new FlushClient(set_tool_status_text);
                this.Invoke(fc);
            }
            else
            {
                this.tool_status_text.Text = "";
            }
        }
        /*
         color = re.findall('colorPictureOptions.+?picturemap(.+?)}};', con, re.S)  颜色图片
                ['":{"4549337605428":"http://img.muji.net/img/item/4549337605428_400.jpg","4549337605466":"http://img.muji.net/img/item/4549337605466_400.jpg","4549337605503":"http://img.muji.net/img/item/4549337605503_400.jpg"']
         re.findall('"\d+"', color, re.S)
                ['"4549337605428"', '"4549337605466"', '"4549337605503"']
         
         pic = re.findall('relatedPictureOptions .+?picturemap(.+?)}};', con, re.S)[0] 常规预览大图
         re.findall('/(\d+_\d+)_\d+', pic, re.S)
                ['4549337605411_02', '4549337605411_03', '4549337605411_04', '4549337605411_05']
         * 
         re.findall('<div id="sizeList.+?#sizeList -->', con, re.S)  大小说明
         * 
         re.findall('<div id="spec.+?#spec -->', con, re.S)[0] 产品说明
         
         re.findall('figure.+?(<img.+?)</figure', con, re.S) 试穿图片
         */
    }
}
