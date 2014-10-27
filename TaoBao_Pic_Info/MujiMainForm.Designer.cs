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
            this.tbx_urls = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tab_reg = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_spider = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tab_spider.SuspendLayout();
            this.tab_reg.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(129, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.用户名";
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(198, 33);
            this.tbx_user.Multiline = true;
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(235, 33);
            this.tbx_user.TabIndex = 2;
            this.tbx_user.Text = "test";
            // 
            // tbx_com
            // 
            this.tbx_com.Location = new System.Drawing.Point(198, 83);
            this.tbx_com.Multiline = true;
            this.tbx_com.Name = "tbx_com";
            this.tbx_com.ReadOnly = true;
            this.tbx_com.Size = new System.Drawing.Size(237, 42);
            this.tbx_com.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "2.机器码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "3.注册码";
            // 
            // tbx_reg
            // 
            this.tbx_reg.Location = new System.Drawing.Point(198, 147);
            this.tbx_reg.Multiline = true;
            this.tbx_reg.Name = "tbx_reg";
            this.tbx_reg.Size = new System.Drawing.Size(235, 42);
            this.tbx_reg.TabIndex = 6;
            // 
            // btn_create_com
            // 
            this.btn_create_com.Location = new System.Drawing.Point(443, 83);
            this.btn_create_com.Name = "btn_create_com";
            this.btn_create_com.Size = new System.Drawing.Size(87, 42);
            this.btn_create_com.TabIndex = 7;
            this.btn_create_com.Text = "生成机器码";
            this.btn_create_com.UseVisualStyleBackColor = true;
            this.btn_create_com.Click += new System.EventHandler(this.btn_create_com_Click);
            // 
            // btn_check_reg
            // 
            this.btn_check_reg.Location = new System.Drawing.Point(443, 145);
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
            this.tab_main.Location = new System.Drawing.Point(37, 47);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(696, 282);
            this.tab_main.TabIndex = 9;
            // 
            // tab_spider
            // 
            this.tab_spider.Controls.Add(this.label6);
            this.tab_spider.Controls.Add(this.btn_spider);
            this.tab_spider.Controls.Add(this.tbx_urls);
            this.tab_spider.Controls.Add(this.label5);
            this.tab_spider.Location = new System.Drawing.Point(4, 23);
            this.tab_spider.Name = "tab_spider";
            this.tab_spider.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tab_spider.Size = new System.Drawing.Size(688, 255);
            this.tab_spider.TabIndex = 0;
            this.tab_spider.Text = "抓取";
            this.tab_spider.UseVisualStyleBackColor = true;
            // 
            // tbx_urls
            // 
            this.tbx_urls.Location = new System.Drawing.Point(56, 19);
            this.tbx_urls.Multiline = true;
            this.tbx_urls.Name = "tbx_urls";
            this.tbx_urls.Size = new System.Drawing.Size(544, 103);
            this.tbx_urls.TabIndex = 1;
            this.tbx_urls.Text = "http://www.muji.net/store/cmdty/detail/4549337291867";
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
            this.tab_reg.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tab_reg.Size = new System.Drawing.Size(688, 255);
            this.tab_reg.TabIndex = 1;
            this.tab_reg.Text = "验证帐号";
            this.tab_reg.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 7F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(208, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "步骤：输入用户名，生成验证码，联系[张志鹏]\r\n\r\n索要注册码，复制到注册码一栏，验证通过即可。\r\n";
            // 
            // btn_spider
            // 
            this.btn_spider.Location = new System.Drawing.Point(492, 142);
            this.btn_spider.Name = "btn_spider";
            this.btn_spider.Size = new System.Drawing.Size(108, 41);
            this.btn_spider.TabIndex = 2;
            this.btn_spider.Text = "开 始 抓 取";
            this.btn_spider.UseVisualStyleBackColor = true;
            this.btn_spider.Click += new System.EventHandler(this.btn_spider_Click);
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
            // MujiMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 386);
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
            this.Text = "无良印品";
            this.Load += new System.EventHandler(this.MujiMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.tab_spider.ResumeLayout(false);
            this.tab_spider.PerformLayout();
            this.tab_reg.ResumeLayout(false);
            this.tab_reg.PerformLayout();
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
        private System.Windows.Forms.TextBox tbx_urls;
        private System.Windows.Forms.Button btn_spider;
        private System.Windows.Forms.Label label6;
    }
}

