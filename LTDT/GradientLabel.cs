﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT
{
    public class GradientLabel : Label
    {
        private Color backgroundColorTop;
        private Color backgroundColorBottom;
        private Color textColorTop = Color.Black;
        private Color textColorBottom = Color.Black;
        private float backgroundGradientAngel;
        private float textGradientAngel;
        private StringAlignment aligntment = StringAlignment.Center;
        private StringAlignment lineAlignment = StringAlignment.Center;

        public Color BackgroundColorTop { get => backgroundColorTop; set => backgroundColorTop = value; }
        public Color BackgroundColorBottom { get => backgroundColorBottom; set => backgroundColorBottom = value; }
        public Color TextColorTop { get => textColorTop; set => textColorTop = value; }
        public Color TextColorBottom { get => textColorBottom; set => textColorBottom = value; }
        public float BackgroundGradientAngel { get => backgroundGradientAngel; set => backgroundGradientAngel = value; }
        public float TextGradientAngel { get => textGradientAngel; set => textGradientAngel = value; }
        public StringAlignment Aligntment { get => aligntment; set => aligntment = value; }
        public StringAlignment LineAlignment { get => lineAlignment; set => lineAlignment = value; }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush backgroundGradientBrush = new LinearGradientBrush(this.ClientRectangle, this.BackgroundColorTop, this.BackgroundColorBottom, this.BackgroundGradientAngel);
            Graphics graphic = e.Graphics;
            graphic.FillRectangle(backgroundGradientBrush, this.ClientRectangle);

            Rectangle rect = new Rectangle(0 - 5, 0, this.Width + 10, this.Height);
            LinearGradientBrush textGradientBrush = new LinearGradientBrush(this.ClientRectangle, this.TextColorTop, this.TextColorBottom, this.TextGradientAngel);
            StringFormat stringFormat = new StringFormat()
            {
                LineAlignment = Aligntment,
                Alignment = LineAlignment,
                FormatFlags = StringFormatFlags.NoWrap,
                //Trimming = StringTrimming.EllipsisCharacter
            };
            e.Graphics.DrawString(this.Text, this.Font, textGradientBrush, rect, stringFormat);
        }
    }
}