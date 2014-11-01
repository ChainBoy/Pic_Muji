namespace TaoBao_Pic_Info
{
    partial class MujiMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MujiMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tool_loginon = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_spider = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.tbx_com = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_reg = new System.Windows.Forms.TextBox();
            this.btn_create_com = new System.Windows.Forms.Button();
            this.btn_check_reg = new System.Windows.Forms.Button();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tab_spider = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbx_urls = new System.Windows.Forms.RichTextBox();
            this.rtbx_say = new System.Windows.Forms.RichTextBox();
            this.rtbx_style = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_spider = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tab_reg = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_status_reg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_status_spider = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_status_probar = new System.Windows.Forms.ToolStripProgressBar();
            this.tool_status_text = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_div = new System.Windows.Forms.Label();
            this.lab_img = new System.Windows.Forms.Label();
            this.lab_table = new System.Windows.Forms.Label();
            this.lab_td = new System.Windows.Forms.Label();
            this.lab_th_size = new System.Windows.Forms.Label();
            this.lab_th_shop = new System.Windows.Forms.Label();
            this.lab_p = new System.Windows.Forms.Label();
            this.lab_span = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tab_spider.SuspendLayout();
            this.tab_reg.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_loginon,
            this.tool_spider,
            this.tool_exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(783, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tool_loginon
            // 
            this.tool_loginon.Name = "tool_loginon";
            this.tool_loginon.Size = new System.Drawing.Size(44, 21);
            this.tool_loginon.Text = "验证";
            this.tool_loginon.Click += new System.EventHandler(this.tool_loginon_Click);
            // 
            // tool_spider
            // 
            this.tool_spider.Name = "tool_spider";
            this.tool_spider.Size = new System.Drawing.Size(44, 21);
            this.tool_spider.Text = "抓取";
            this.tool_spider.Click += new System.EventHandler(this.tool_spider_Click);
            // 
            // tool_exit
            // 
            this.tool_exit.Name = "tool_exit";
            this.tool_exit.Size = new System.Drawing.Size(44, 21);
            this.tool_exit.Text = "退出";
            this.tool_exit.Click += new System.EventHandler(this.tool_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.用户名";
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(121, 31);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(235, 23);
            this.tbx_user.TabIndex = 2;
            this.tbx_user.Text = "test";
            // 
            // tbx_com
            // 
            this.tbx_com.Location = new System.Drawing.Point(121, 80);
            this.tbx_com.Name = "tbx_com";
            this.tbx_com.ReadOnly = true;
            this.tbx_com.Size = new System.Drawing.Size(237, 23);
            this.tbx_com.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "2.机器码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "3.注册码";
            // 
            // tbx_reg
            // 
            this.tbx_reg.Location = new System.Drawing.Point(121, 124);
            this.tbx_reg.Multiline = true;
            this.tbx_reg.Name = "tbx_reg";
            this.tbx_reg.Size = new System.Drawing.Size(235, 42);
            this.tbx_reg.TabIndex = 6;
            // 
            // btn_create_com
            // 
            this.btn_create_com.Location = new System.Drawing.Point(366, 80);
            this.btn_create_com.Name = "btn_create_com";
            this.btn_create_com.Size = new System.Drawing.Size(87, 29);
            this.btn_create_com.TabIndex = 7;
            this.btn_create_com.Text = "生成机器码";
            this.btn_create_com.UseVisualStyleBackColor = true;
            this.btn_create_com.Click += new System.EventHandler(this.btn_create_com_Click);
            // 
            // btn_check_reg
            // 
            this.btn_check_reg.Location = new System.Drawing.Point(366, 122);
            this.btn_check_reg.Name = "btn_check_reg";
            this.btn_check_reg.Size = new System.Drawing.Size(87, 44);
            this.btn_check_reg.TabIndex = 8;
            this.btn_check_reg.Text = "验  证";
            this.btn_check_reg.UseVisualStyleBackColor = true;
            this.btn_check_reg.Click += new System.EventHandler(this.btn_check_reg_Click);
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.tab_spider);
            this.tab_main.Controls.Add(this.tab_reg);
            this.tab_main.Location = new System.Drawing.Point(37, 35);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(696, 282);
            this.tab_main.TabIndex = 9;
            this.tab_main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab_main_Selecting);
            // 
            // tab_spider
            // 
            this.tab_spider.Controls.Add(this.lab_span);
            this.tab_spider.Controls.Add(this.lab_p);
            this.tab_spider.Controls.Add(this.lab_th_shop);
            this.tab_spider.Controls.Add(this.lab_th_size);
            this.tab_spider.Controls.Add(this.lab_td);
            this.tab_spider.Controls.Add(this.lab_table);
            this.tab_spider.Controls.Add(this.lab_img);
            this.tab_spider.Controls.Add(this.lab_div);
            this.tab_spider.Controls.Add(this.label9);
            this.tab_spider.Controls.Add(this.rtbx_urls);
            this.tab_spider.Controls.Add(this.rtbx_say);
            this.tab_spider.Controls.Add(this.rtbx_style);
            this.tab_spider.Controls.Add(this.label6);
            this.tab_spider.Controls.Add(this.btn_spider);
            this.tab_spider.Controls.Add(this.label5);
            this.tab_spider.Location = new System.Drawing.Point(4, 23);
            this.tab_spider.Name = "tab_spider";
            this.tab_spider.Padding = new System.Windows.Forms.Padding(3);
            this.tab_spider.Size = new System.Drawing.Size(688, 255);
            this.tab_spider.TabIndex = 0;
            this.tab_spider.Text = "抓取";
            this.tab_spider.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(553, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "在软件所在目录下添加模版CSV文件，文件名【template.csv】，替换项用【#U#】代替。";
            // 
            // rtbx_urls
            // 
            this.rtbx_urls.DetectUrls = false;
            this.rtbx_urls.Location = new System.Drawing.Point(56, 22);
            this.rtbx_urls.Name = "rtbx_urls";
            this.rtbx_urls.Size = new System.Drawing.Size(544, 96);
            this.rtbx_urls.TabIndex = 8;
            this.rtbx_urls.Text = "http://www.muji.net/store/cmdty/detail/4549337291867\nhttp://www.muji.net/store/cm" +
                "dty/detail/4549337339378\nhttp://www.muji.net/store/cmdty/detail/4549337294202";
            // 
            // rtbx_say
            // 
            this.rtbx_say.Location = new System.Drawing.Point(56, 142);
            this.rtbx_say.Name = "rtbx_say";
            this.rtbx_say.Size = new System.Drawing.Size(291, 41);
            this.rtbx_say.TabIndex = 6;
            this.rtbx_say.Text = "亲，本店宝贝100%日本无印良品正品，假一闭店。代购时间15-25天左右，非质量问题不退换~本店可以提供日本购买凭证和EMS的物流证明~本店非七天无理由退换店铺，" +
                "一旦下单，中途不能取消订单或者变更订单，请谅解~";
            this.rtbx_say.Visible = false;
            // 
            // rtbx_style
            // 
            this.rtbx_style.Location = new System.Drawing.Point(369, 142);
            this.rtbx_style.Name = "rtbx_style";
            this.rtbx_style.Size = new System.Drawing.Size(97, 37);
            this.rtbx_style.TabIndex = 5;
            this.rtbx_style.Text = resources.GetString("rtbx_style.Text");
            this.rtbx_style.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(53, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "内容会自动保存到商品ID所对应的文件中。";
            // 
            // btn_spider
            // 
            this.btn_spider.Location = new System.Drawing.Point(492, 172);
            this.btn_spider.Name = "btn_spider";
            this.btn_spider.Size = new System.Drawing.Size(108, 41);
            this.btn_spider.TabIndex = 2;
            this.btn_spider.Text = "开 始 抓 取";
            this.btn_spider.UseVisualStyleBackColor = true;
            this.btn_spider.Click += new System.EventHandler(this.btn_spider_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "URL";
            // 
            // tab_reg
            // 
            this.tab_reg.Controls.Add(this.linkLabel3);
            this.tab_reg.Controls.Add(this.linkLabel2);
            this.tab_reg.Controls.Add(this.linkLabel1);
            this.tab_reg.Controls.Add(this.label7);
            this.tab_reg.Controls.Add(this.label4);
            this.tab_reg.Controls.Add(this.btn_create_com);
            this.tab_reg.Controls.Add(this.btn_check_reg);
            this.tab_reg.Controls.Add(this.label1);
            this.tab_reg.Controls.Add(this.tbx_user);
            this.tab_reg.Controls.Add(this.tbx_reg);
            this.tab_reg.Controls.Add(this.label2);
            this.tab_reg.Controls.Add(this.label3);
            this.tab_reg.Controls.Add(this.tbx_com);
            this.tab_reg.Location = new System.Drawing.Point(4, 23);
            this.tab_reg.Name = "tab_reg";
            this.tab_reg.Padding = new System.Windows.Forms.Padding(3);
            this.tab_reg.Size = new System.Drawing.Size(688, 255);
            this.tab_reg.TabIndex = 1;
            this.tab_reg.Text = "验证帐号";
            this.tab_reg.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("宋体", 9F);
            this.linkLabel3.Location = new System.Drawing.Point(176, 217);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(65, 12);
            this.linkLabel3.TabIndex = 13;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "1126918258";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 9F);
            this.linkLabel2.Location = new System.Drawing.Point(442, 217);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(137, 12);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "qq1126918258@gmail.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(485, 116);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "授权人";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 8.5F);
            this.label7.Location = new System.Drawing.Point(459, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 108);
            this.label7.TabIndex = 10;
            this.label7.Text = "软件售价：4000RMB/人/帐号/电脑/\r\n\r\n交易方式：支付宝账户13869139163\r\n\r\n支付宝打款，备注机器码和用户名\r\n\r\n联系授权人 索取软件注册" +
                "码。\r\n\r\n给您省出来的不止4000RMB，非诚勿扰。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(52, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(527, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "步骤：输入用户名，生成验证码，联系开发者索要注册码，复制到注册码一栏，验证通过即可。\r\n\r\n联系人：张经理   QQ：1126918258   联系电话：1386" +
                "9139163   Email：qq1126918258@gmail.com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 8.2F);
            this.label8.Location = new System.Drawing.Point(40, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(566, 33);
            this.label8.TabIndex = 11;
            this.label8.Text = "本工具禁止以任何形式的编译、反编译、调试、修改等学习或交流，不允许用于商业、个人、集体等非法牟利用途，\r\n禁止使用者向第三方扩散、复制！使用者只有使用权！如违反使" +
                "用约定，作者有权获取使用者所牟利等额价值80%，\r\n并且收回软件使用权！软件所有权归作者【ChainBoy】所有！版权所有，受著作法保护！";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_status_reg,
            this.tool_status_spider,
            this.tool_status_probar,
            this.tool_status_text});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(783, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_status_reg
            // 
            this.tool_status_reg.Name = "tool_status_reg";
            this.tool_status_reg.Size = new System.Drawing.Size(56, 17);
            this.tool_status_reg.Text = "尚未注册";
            // 
            // tool_status_spider
            // 
            this.tool_status_spider.Name = "tool_status_spider";
            this.tool_status_spider.Size = new System.Drawing.Size(80, 17);
            this.tool_status_spider.Text = "任务尚未开始";
            // 
            // tool_status_probar
            // 
            this.tool_status_probar.Maximum = 0;
            this.tool_status_probar.Name = "tool_status_probar";
            this.tool_status_probar.Size = new System.Drawing.Size(100, 16);
            this.tool_status_probar.Step = 1;
            // 
            // tool_status_text
            // 
            this.tool_status_text.Name = "tool_status_text";
            this.tool_status_text.Size = new System.Drawing.Size(27, 17);
            this.tool_status_text.Text = "0/0";
            // 
            // lab_div
            // 
            this.lab_div.AutoSize = true;
            this.lab_div.Location = new System.Drawing.Point(53, 214);
            this.lab_div.Name = "lab_div";
            this.lab_div.Size = new System.Drawing.Size(1428, 14);
            this.lab_div.TabIndex = 10;
            this.lab_div.Text = resources.GetString("lab_div.Text");
            this.lab_div.Visible = false;
            // 
            // lab_img
            // 
            this.lab_img.AutoSize = true;
            this.lab_img.Location = new System.Drawing.Point(53, 228);
            this.lab_img.Name = "lab_img";
            this.lab_img.Size = new System.Drawing.Size(182, 14);
            this.lab_img.TabIndex = 11;
            this.lab_img.Text = "style=\"margin: 15px 0px;\"";
            this.lab_img.Visible = false;
            // 
            // lab_table
            // 
            this.lab_table.AutoSize = true;
            this.lab_table.Location = new System.Drawing.Point(241, 228);
            this.lab_table.Name = "lab_table";
            this.lab_table.Size = new System.Drawing.Size(392, 14);
            this.lab_table.TabIndex = 11;
            this.lab_table.Text = "style=\"border-collapse: collapse; border-spacing: 0px;\"";
            this.lab_table.Visible = false;
            // 
            // lab_td
            // 
            this.lab_td.AutoSize = true;
            this.lab_td.Location = new System.Drawing.Point(53, 244);
            this.lab_td.Name = "lab_td";
            this.lab_td.Size = new System.Drawing.Size(875, 14);
            this.lab_td.TabIndex = 11;
            this.lab_td.Text = "style=\"padding: 10px; border-style: solid; border-color: rgb(221, 221, 221); bord" +
                "er-width: 0px 1px 1px; text-align: center;\"";
            this.lab_td.Visible = false;
            // 
            // lab_th_size
            // 
            this.lab_th_size.AutoSize = true;
            this.lab_th_size.Location = new System.Drawing.Point(606, 40);
            this.lab_th_size.Name = "lab_th_size";
            this.lab_th_size.Size = new System.Drawing.Size(1239, 14);
            this.lab_th_size.TabIndex = 11;
            this.lab_th_size.Text = "style=\"padding: 5px 10px;background: #f5f5f5;text-align: center;font-weight: bold" +
                ";border: solid #ddd;border-width: 1px 1px 0;border-bottom: 1px solid #ddd;font-w" +
                "eight: normal;\"";
            this.lab_th_size.Visible = false;
            // 
            // lab_th_shop
            // 
            this.lab_th_shop.AutoSize = true;
            this.lab_th_shop.Location = new System.Drawing.Point(606, 55);
            this.lab_th_shop.Name = "lab_th_shop";
            this.lab_th_shop.Size = new System.Drawing.Size(1078, 14);
            this.lab_th_shop.TabIndex = 11;
            this.lab_th_shop.Text = "style=\"padding: 10px;border: solid #ddd;border-width: 1px 0 1px 1px;background: #" +
                "f5f5f5;font-weight: normal;width: 245px;width: 80px;text-align: center;\"";
            this.lab_th_shop.Visible = false;
            // 
            // lab_p
            // 
            this.lab_p.AutoSize = true;
            this.lab_p.Location = new System.Drawing.Point(606, 69);
            this.lab_p.Name = "lab_p";
            this.lab_p.Size = new System.Drawing.Size(189, 14);
            this.lab_p.TabIndex = 11;
            this.lab_p.Text = "style=\"text-indent: 28pt;\"";
            this.lab_p.Visible = false;
            // 
            // lab_span
            // 
            this.lab_span.AutoSize = true;
            this.lab_span.Location = new System.Drawing.Point(606, 83);
            this.lab_span.Name = "lab_span";
            this.lab_span.Size = new System.Drawing.Size(420, 14);
            this.lab_span.TabIndex = 11;
            this.lab_span.Text = "style=\"font-size: 14pt; font-family: 华文楷体; color: red;\"";
            this.lab_span.Visible = false;
            // 
            // MujiMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 386);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tab_main);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(789, 414);
            this.MinimumSize = new System.Drawing.Size(789, 414);
            this.Name = "MujiMainForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "无良印品 - By:ChainBoy QQ:1126918258  Email:qq1126918258@gmail.com";
            this.Load += new System.EventHandler(this.MujiMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.tab_spider.ResumeLayout(false);
            this.tab_spider.PerformLayout();
            this.tab_reg.ResumeLayout(false);
            this.tab_reg.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tool_spider;
        private System.Windows.Forms.ToolStripMenuItem tool_exit;
        private System.Windows.Forms.ToolStripMenuItem tool_loginon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.TextBox tbx_com;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_reg;
        private System.Windows.Forms.Button btn_create_com;
        private System.Windows.Forms.Button btn_check_reg;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.TabPage tab_spider;
        private System.Windows.Forms.TabPage tab_reg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_spider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbx_style;
        private System.Windows.Forms.RichTextBox rtbx_say;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tool_status_reg;
        private System.Windows.Forms.ToolStripStatusLabel tool_status_spider;
        private System.Windows.Forms.ToolStripProgressBar tool_status_probar;
        private System.Windows.Forms.ToolStripStatusLabel tool_status_text;
        private System.Windows.Forms.RichTextBox rtbx_urls;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label lab_div;
        private System.Windows.Forms.Label lab_img;
        private System.Windows.Forms.Label lab_table;
        private System.Windows.Forms.Label lab_td;
        private System.Windows.Forms.Label lab_th_shop;
        private System.Windows.Forms.Label lab_th_size;
        private System.Windows.Forms.Label lab_p;
        private System.Windows.Forms.Label lab_span;
    }
}

