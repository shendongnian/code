        protected override void OnPaint(PaintEventArgs e)
        {
            string sample = "abc                       defXXXXXXXXXXXXiiiiiiiX";
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.TextBoxControl | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix;
            TextRenderer.DrawText(e.Graphics, sample, this.Font, Point.Empty, Color.Black, flags);
            e.Graphics.DrawLine(Pens.Red, trackBar1.Value, 0, trackBar1.Value, 100);
            string measuredString = sample;
            for (int i = 0; i < sample.Length; i++)
            {
                Size size = TextRenderer.MeasureText(e.Graphics, sample.Substring(0, i+1), this.Font, new Size(10000000, 1000000), flags);
                if (size.Width > trackBar1.Value)
                {
                    textBox1.Text = "[" + sample.Substring(0,i+1) + "]";
                    break;
                }
            }
            base.OnPaint(e);
        }
