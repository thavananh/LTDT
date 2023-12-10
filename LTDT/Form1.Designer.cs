namespace LTDT
{
    partial class Form1
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
            this.gradientLabel1 = new LTDT.GradientLabel();
            this.SuspendLayout();
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.Aligntment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackgroundColorBottom = System.Drawing.Color.Empty;
            this.gradientLabel1.BackgroundColorTop = System.Drawing.Color.Empty;
            this.gradientLabel1.BackgroundGradientAngel = 0F;
            this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.Location = new System.Drawing.Point(199, 144);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(77, 13);
            this.gradientLabel1.TabIndex = 0;
            this.gradientLabel1.Text = "gradientLabel1";
            this.gradientLabel1.TextColorBottom = System.Drawing.Color.Black;
            this.gradientLabel1.TextColorTop = System.Drawing.Color.Black;
            this.gradientLabel1.TextGradientAngel = 0F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gradientLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GradientLabel gradientLabel1;
    }
}

