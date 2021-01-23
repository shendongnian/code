        //paint event from button:
        private void button1_Paint(object sender, PaintEventArgs e)
        {
            float fontSize = NewFontSize(e.Graphics, button1.Size, button1.Font, button1.Text);
            // set font with Font Class and the returned Size from NewFontSize();
            Font f = new Font("Arial", fontSize, FontStyle.Bold);
            button1.Font = f;
        }
        // method to calculate the size for the font:
        public static float NewFontSize(Graphics graphics, Size size, Font font, string str)
        {
            SizeF stringSize = graphics.MeasureString(str, font);
            float wRatio = size.Width / stringSize.Width;
            float hRatio = size.Height / stringSize.Height;
            float ratio = Math.Min(hRatio, wRatio);
            return font.Size * ratio;
        }
