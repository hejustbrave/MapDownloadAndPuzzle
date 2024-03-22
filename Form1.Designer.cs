namespace Tifer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pn = new Panel();
            chkGrid = new CheckBox();
            tbLng = new TextBox();
            tbZoom = new TextBox();
            tbLat = new TextBox();
            btnCrawl = new Button();
            btnDraw = new Button();
            btnClear = new Button();
            tbCrawlOutput = new TextBox();
            btnCrawlOutput = new Button();
            tbToken = new TextBox();
            label1 = new Label();
            btnLoad = new Button();
            gb = new GroupBox();
            btnCombineOutput = new Button();
            tbCombineOutput = new TextBox();
            lbCombine = new Label();
            lbCrawl = new Label();
            btnCombine = new Button();
            tbTileExtent = new TextBox();
            label2 = new Label();
            nudZoom = new NumericUpDown();
            tbExtent = new TextBox();
            pn.SuspendLayout();
            gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudZoom).BeginInit();
            SuspendLayout();
            // 
            // pn
            // 
            pn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn.Controls.Add(chkGrid);
            pn.Location = new Point(12, 11);
            pn.Name = "pn";
            pn.Size = new Size(844, 725);
            pn.TabIndex = 0;
            // 
            // chkGrid
            // 
            chkGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chkGrid.AutoSize = true;
            chkGrid.BackColor = Color.Transparent;
            chkGrid.Location = new Point(790, 701);
            chkGrid.Name = "chkGrid";
            chkGrid.Size = new Size(51, 21);
            chkGrid.TabIndex = 4;
            chkGrid.Text = "网格";
            chkGrid.UseVisualStyleBackColor = false;
            chkGrid.CheckedChanged += chkGrid_CheckedChanged;
            // 
            // tbLng
            // 
            tbLng.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbLng.Location = new Point(896, 98);
            tbLng.Name = "tbLng";
            tbLng.ReadOnly = true;
            tbLng.Size = new Size(143, 23);
            tbLng.TabIndex = 7;
            // 
            // tbZoom
            // 
            tbZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbZoom.Location = new Point(862, 98);
            tbZoom.Name = "tbZoom";
            tbZoom.ReadOnly = true;
            tbZoom.Size = new Size(28, 23);
            tbZoom.TabIndex = 1;
            // 
            // tbLat
            // 
            tbLat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbLat.Location = new Point(1044, 98);
            tbLat.Name = "tbLat";
            tbLat.ReadOnly = true;
            tbLat.Size = new Size(143, 23);
            tbLat.TabIndex = 8;
            // 
            // btnCrawl
            // 
            btnCrawl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCrawl.Location = new Point(6, 440);
            btnCrawl.Name = "btnCrawl";
            btnCrawl.Size = new Size(313, 41);
            btnCrawl.TabIndex = 3;
            btnCrawl.Text = "1.开爬";
            btnCrawl.UseVisualStyleBackColor = true;
            btnCrawl.Click += btnExecute_Click;
            // 
            // btnDraw
            // 
            btnDraw.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDraw.Location = new Point(6, 22);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(153, 36);
            btnDraw.TabIndex = 5;
            btnDraw.Text = "开始框选";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(165, 22);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(154, 36);
            btnClear.TabIndex = 6;
            btnClear.Text = "清空绘制";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // tbCrawlOutput
            // 
            tbCrawlOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbCrawlOutput.Location = new Point(6, 411);
            tbCrawlOutput.Name = "tbCrawlOutput";
            tbCrawlOutput.Size = new Size(313, 23);
            tbCrawlOutput.TabIndex = 9;
            // 
            // btnCrawlOutput
            // 
            btnCrawlOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCrawlOutput.Location = new Point(6, 382);
            btnCrawlOutput.Name = "btnCrawlOutput";
            btnCrawlOutput.Size = new Size(103, 23);
            btnCrawlOutput.TabIndex = 10;
            btnCrawlOutput.Text = "选择爬取文件夹";
            btnCrawlOutput.UseVisualStyleBackColor = true;
            btnCrawlOutput.Click += btnOutput_Click;
            // 
            // tbToken
            // 
            tbToken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbToken.Location = new Point(862, 32);
            tbToken.Name = "tbToken";
            tbToken.Size = new Size(325, 23);
            tbToken.TabIndex = 11;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(862, 12);
            label1.Name = "label1";
            label1.Size = new Size(83, 17);
            label1.TabIndex = 12;
            label1.Text = "天地图Token:";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoad.Location = new Point(862, 61);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(325, 31);
            btnLoad.TabIndex = 13;
            btnLoad.Text = "加载影像";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // gb
            // 
            gb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gb.Controls.Add(btnCombineOutput);
            gb.Controls.Add(tbCombineOutput);
            gb.Controls.Add(lbCombine);
            gb.Controls.Add(lbCrawl);
            gb.Controls.Add(btnCombine);
            gb.Controls.Add(tbTileExtent);
            gb.Controls.Add(label2);
            gb.Controls.Add(nudZoom);
            gb.Controls.Add(tbExtent);
            gb.Controls.Add(btnCrawlOutput);
            gb.Controls.Add(tbCrawlOutput);
            gb.Controls.Add(btnCrawl);
            gb.Controls.Add(btnDraw);
            gb.Controls.Add(btnClear);
            gb.Location = new Point(862, 141);
            gb.Name = "gb";
            gb.Size = new Size(325, 595);
            gb.TabIndex = 14;
            gb.TabStop = false;
            gb.Text = "操作框";
            // 
            // btnCombineOutput
            // 
            btnCombineOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCombineOutput.Location = new Point(9, 494);
            btnCombineOutput.Name = "btnCombineOutput";
            btnCombineOutput.Size = new Size(100, 23);
            btnCombineOutput.TabIndex = 19;
            btnCombineOutput.Text = "选择瓦片文件夹";
            btnCombineOutput.UseVisualStyleBackColor = true;
            btnCombineOutput.Click += btnCombineOutput_Click;
            // 
            // tbCombineOutput
            // 
            tbCombineOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbCombineOutput.Location = new Point(6, 523);
            tbCombineOutput.Name = "tbCombineOutput";
            tbCombineOutput.Size = new Size(313, 23);
            tbCombineOutput.TabIndex = 18;
            // 
            // lbCombine
            // 
            lbCombine.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbCombine.AutoSize = true;
            lbCombine.Location = new Point(159, 572);
            lbCombine.Name = "lbCombine";
            lbCombine.Size = new Size(0, 17);
            lbCombine.TabIndex = 17;
            // 
            // lbCrawl
            // 
            lbCrawl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbCrawl.AutoSize = true;
            lbCrawl.Location = new Point(146, 484);
            lbCrawl.Name = "lbCrawl";
            lbCrawl.Size = new Size(0, 17);
            lbCrawl.TabIndex = 16;
            // 
            // btnCombine
            // 
            btnCombine.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCombine.Location = new Point(6, 552);
            btnCombine.Name = "btnCombine";
            btnCombine.Size = new Size(313, 41);
            btnCombine.TabIndex = 15;
            btnCombine.Text = "2.拼图";
            btnCombine.UseVisualStyleBackColor = true;
            btnCombine.Click += btnCombine_Click;
            // 
            // tbTileExtent
            // 
            tbTileExtent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbTileExtent.Location = new Point(9, 144);
            tbTileExtent.Multiline = true;
            tbTileExtent.Name = "tbTileExtent";
            tbTileExtent.ReadOnly = true;
            tbTileExtent.Size = new Size(310, 47);
            tbTileExtent.TabIndex = 14;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(9, 119);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 13;
            label2.Text = "爬取级别";
            // 
            // nudZoom
            // 
            nudZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudZoom.Location = new Point(65, 117);
            nudZoom.Name = "nudZoom";
            nudZoom.Size = new Size(44, 23);
            nudZoom.TabIndex = 12;
            nudZoom.ValueChanged += nudZoom_ValueChanged;
            // 
            // tbExtent
            // 
            tbExtent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbExtent.Location = new Point(9, 64);
            tbExtent.Multiline = true;
            tbExtent.Name = "tbExtent";
            tbExtent.ReadOnly = true;
            tbExtent.Size = new Size(310, 47);
            tbExtent.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 746);
            Controls.Add(tbLng);
            Controls.Add(btnLoad);
            Controls.Add(tbZoom);
            Controls.Add(label1);
            Controls.Add(tbLat);
            Controls.Add(tbToken);
            Controls.Add(pn);
            Controls.Add(gb);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HE-Tifer";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            pn.ResumeLayout(false);
            pn.PerformLayout();
            gb.ResumeLayout(false);
            gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudZoom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pn;
        private TextBox tbZoom;
        private Button btnCrawl;
        private CheckBox chkGrid;
        private Button btnDraw;
        private Button btnClear;
        private TextBox tbLng;
        private TextBox tbLat;
        private TextBox tbCrawlOutput;
        private Button btnCrawlOutput;
        private TextBox tbToken;
        private Label label1;
        private Button btnLoad;
        private GroupBox gb;
        private TextBox tbExtent;
        private Label label2;
        private NumericUpDown nudZoom;
        private TextBox tbTileExtent;
        private Button btnCombine;
        private Label lbCrawl;
        private Label lbCombine;
        private TextBox tbCombineOutput;
        private Button btnCombineOutput;
    }
}
