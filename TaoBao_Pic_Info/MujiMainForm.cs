﻿using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace TaoBao_Pic_Info
{
    public partial class MujiMainForm : Form
    {
        private const string SETTING_PATH = ".s";
        private static bool PASS = false;
        private static string PIC_URL_START = "http://img.muji.net/img/item/";
        private static string PIC_URL_END = "_400.jpg";
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
            spider_work();
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
                return;
            }
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
                imgs_html += "<img src=\"" + pic_urls[i] + "\"width=\"400\" height=\"400\" >";
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
