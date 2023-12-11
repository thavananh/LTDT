﻿namespace LTDT
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
            this.gradientPanel1 = new LTDT.GradientPanel();
            this.SuspendLayout();
            // 
            // rdoDFS
            // 
            this.rdoDFS.AutoSize = true;
            this.rdoDFS.Location = new System.Drawing.Point(9, 30);
            this.rdoDFS.Name = "rdoDFS";
            this.rdoDFS.Size = new System.Drawing.Size(49, 19);
            this.rdoDFS.TabIndex = 1;
            this.rdoDFS.TabStop = true;
            this.rdoDFS.Text = "DFS";
            this.rdoDFS.UseVisualStyleBackColor = true;
            // 
            // rdoBFS
            // 
            this.rdoBFS.AutoSize = true;
            this.rdoBFS.Location = new System.Drawing.Point(74, 30);
            this.rdoBFS.Name = "rdoBFS";
            this.rdoBFS.Size = new System.Drawing.Size(48, 19);
            this.rdoBFS.TabIndex = 2;
            this.rdoBFS.TabStop = true;
            this.rdoBFS.Text = "BFS";
            this.rdoBFS.UseVisualStyleBackColor = true;
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
            this.gradientPanel1.Location = new System.Drawing.Point(9, 52);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(614, 472);
            this.gradientPanel1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1073, 533);
            this.Controls.Add(this.rdoBFS);
            this.Controls.Add(this.rdoDFS);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.RadioButton rdoDFS;
        private System.Windows.Forms.RadioButton rdoBFS;
    }
}