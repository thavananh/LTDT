namespace LTDT
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoDFS = new System.Windows.Forms.RadioButton();
            this.rdoBFS = new System.Windows.Forms.RadioButton();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.rtxKetQua = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstvMaTranKe = new System.Windows.Forms.ListView();
            this.gradientLabel3 = new LTDT.GradientLabel();
            this.gradientLabel2 = new LTDT.GradientLabel();
            this.gradientPanel2 = new LTDT.GradientPanel();
            this.gradientLabel1 = new LTDT.GradientLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientPanel1 = new LTDT.GradientPanel();
            this.panel1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoDFS
            // 
            this.rdoDFS.AutoSize = true;
            this.rdoDFS.Checked = true;
            this.rdoDFS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDFS.ForeColor = System.Drawing.Color.DarkOrange;
            this.rdoDFS.Location = new System.Drawing.Point(16, 122);
            this.rdoDFS.Name = "rdoDFS";
            this.rdoDFS.Size = new System.Drawing.Size(51, 20);
            this.rdoDFS.TabIndex = 1;
            this.rdoDFS.TabStop = true;
            this.rdoDFS.Text = "DFS";
            this.rdoDFS.UseVisualStyleBackColor = true;
            // 
            // rdoBFS
            // 
            this.rdoBFS.AutoSize = true;
            this.rdoBFS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBFS.ForeColor = System.Drawing.Color.Coral;
            this.rdoBFS.Location = new System.Drawing.Point(80, 123);
            this.rdoBFS.Name = "rdoBFS";
            this.rdoBFS.Size = new System.Drawing.Size(51, 20);
            this.rdoBFS.TabIndex = 2;
            this.rdoBFS.Text = "BFS";
            this.rdoBFS.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(299, 120);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(98, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnXoaCoVaDich_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(218, 120);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(137, 120);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // rtxKetQua
            // 
            this.rtxKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxKetQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(182)))), ((int)(((byte)(197)))));
            this.rtxKetQua.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxKetQua.Location = new System.Drawing.Point(9, 304);
            this.rtxKetQua.Name = "rtxKetQua";
            this.rtxKetQua.Size = new System.Drawing.Size(325, 99);
            this.rtxKetQua.TabIndex = 6;
            this.rtxKetQua.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstvMaTranKe);
            this.panel1.Controls.Add(this.gradientLabel3);
            this.panel1.Controls.Add(this.gradientLabel2);
            this.panel1.Controls.Add(this.rtxKetQua);
            this.panel1.Location = new System.Drawing.Point(419, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 406);
            this.panel1.TabIndex = 10;
            // 
            // lstvMaTranKe
            // 
            this.lstvMaTranKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvMaTranKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(182)))), ((int)(((byte)(197)))));
            this.lstvMaTranKe.HideSelection = false;
            this.lstvMaTranKe.Location = new System.Drawing.Point(9, 38);
            this.lstvMaTranKe.Name = "lstvMaTranKe";
            this.lstvMaTranKe.Size = new System.Drawing.Size(325, 221);
            this.lstvMaTranKe.TabIndex = 11;
            this.lstvMaTranKe.UseCompatibleStateImageBehavior = false;
            this.lstvMaTranKe.View = System.Windows.Forms.View.Details;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.Aligntment = System.Drawing.StringAlignment.Center;
            this.gradientLabel3.AutoSize = true;
            this.gradientLabel3.BackgroundColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel3.BackgroundColorTop = System.Drawing.Color.Empty;
            this.gradientLabel3.BackgroundGradientAngel = 0F;
            this.gradientLabel3.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel3.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel3.Location = new System.Drawing.Point(126, 273);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(91, 27);
            this.gradientLabel3.TabIndex = 10;
            this.gradientLabel3.Text = "Kết quả";
            this.gradientLabel3.TextColorBottom = System.Drawing.Color.Lime;
            this.gradientLabel3.TextColorTop = System.Drawing.Color.Gold;
            this.gradientLabel3.TextGradientAngel = 0F;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.Aligntment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.AutoSize = true;
            this.gradientLabel2.BackgroundColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel2.BackgroundColorTop = System.Drawing.Color.Empty;
            this.gradientLabel2.BackgroundGradientAngel = 0F;
            this.gradientLabel2.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel2.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.Location = new System.Drawing.Point(111, 8);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(120, 27);
            this.gradientLabel2.TabIndex = 9;
            this.gradientLabel2.Text = "Ma trận kề";
            this.gradientLabel2.TextColorBottom = System.Drawing.Color.Lime;
            this.gradientLabel2.TextColorTop = System.Drawing.Color.Gold;
            this.gradientLabel2.TextGradientAngel = 0F;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel2.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(12)))), ((int)(((byte)(159)))));
            this.gradientPanel2.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(0)))), ((int)(((byte)(93)))));
            this.gradientPanel2.Controls.Add(this.gradientLabel1);
            this.gradientPanel2.Controls.Add(this.pictureBox1);
            this.gradientPanel2.GradientAngle = 90F;
            this.gradientPanel2.Location = new System.Drawing.Point(1, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(772, 114);
            this.gradientPanel2.TabIndex = 8;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.Aligntment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.BackgroundColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel1.BackgroundColorTop = System.Drawing.Color.Empty;
            this.gradientLabel1.BackgroundGradientAngel = 0F;
            this.gradientLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.Location = new System.Drawing.Point(198, 27);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(405, 61);
            this.gradientLabel1.TabIndex = 1;
            this.gradientLabel1.Text = "Graph traversal";
            this.gradientLabel1.TextColorBottom = System.Drawing.Color.Red;
            this.gradientLabel1.TextColorTop = System.Drawing.Color.Yellow;
            this.gradientLabel1.TextGradientAngel = 0F;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LTDT.Properties.Resources.CNTT1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.AutoSize = true;
            this.gradientPanel1.ColorBottom = System.Drawing.Color.Transparent;
            this.gradientPanel1.ColorTop = System.Drawing.Color.Transparent;
            this.gradientPanel1.GradientAngle = 90F;
            this.gradientPanel1.Location = new System.Drawing.Point(9, 146);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(407, 402);
            this.gradientPanel1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(73)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(774, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.rdoBFS);
            this.Controls.Add(this.rdoDFS);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.RadioButton rdoDFS;
        private System.Windows.Forms.RadioButton rdoBFS;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RichTextBox rtxKetQua;
        private GradientPanel gradientPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GradientLabel gradientLabel1;
        private GradientLabel gradientLabel2;
        private System.Windows.Forms.Panel panel1;
        private GradientLabel gradientLabel3;
        private System.Windows.Forms.ListView lstvMaTranKe;
    }
}