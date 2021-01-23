    private void radioButton_Paint(object sender, PaintEventArgs e)
    {
            Graphics graphics = e.Graphics;
            graphics.Clear(BackColor);
            int offset = 2;
            SizeF stringMeasure = graphics.MeasureString(radioButton1.Name, Font);
            // calculate offsets
            int leftOffset = offset + Padding.Left;
            int topOffset = (int)(ClientRectangle.Height - stringMeasure.Height) / 2;
            if (topOffset < 0)
            {
                topOffset = offset + Padding.Top;
            }
            else
            {
                topOffset += Padding.Top;
            }
            graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 0, leftOffset + 10, topOffset + 10);
            graphics.DrawRectangle(new Pen(Color.Green), new Rectangle(0, 0, leftOffset + 10, leftOffset + 10));
            
            graphics.DrawString(radioButton1.Text, (sender as RadioButton).Font, new SolidBrush(Color.IndianRed), 15, 0);
            if( (sender as RadioButton).Checked)
            {
                graphics.FillRectangle(new SolidBrush(Color.Yellow), 1, 1, leftOffset + 8, 10);
            }
    }
