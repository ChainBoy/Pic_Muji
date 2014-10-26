using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaoBao_Pic_Info
{
    public partial class MujiMainForm : Form
    {
        private const string SETTING_PATH = ".s";
        private static bool PASS = false;

        public MujiMainForm()
        {
            InitializeComponent();
        }
        private void btn_create_com_Click(object sender, EventArgs e)
        {
            ComputerCode code = new ComputerCode();
            string user = this.tbx_user.Text.Trim();
            string com = code.getCom(user);
            this.tbx_com.Text = com;

        }

        private void btn_create_reg_Click(object sender, EventArgs e)
        {
            ComputerCode code = new ComputerCode();
            string com = this.tbx_com.Text.Trim();
            string reg = code.getReg(com);
            this.tbx_reg.Text = reg;
        }

        private void btn_check_reg_Click(object sender, EventArgs e)
        {
            if (reg_user())
            {
                MessageBox.Show("恭喜你，注册成功！请妥善保管密钥！");
                this.tab_main.SelectedIndex = 0;
                //todo: 跳转抓取页
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
            ComputerCode code = new ComputerCode();
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
            show();
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
            Comm comm = new Comm();
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
            Comm comm = new Comm();
            Info["user"] = this.tbx_user.Text.Trim();
            Info["com"] = this.tbx_com.Text.Trim();
            Info["reg"] = this.tbx_reg.Text.Trim();
            comm.dump_pick(SETTING_PATH, Info);
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
