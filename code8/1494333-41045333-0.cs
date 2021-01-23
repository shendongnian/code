        private void checkBox1_Paint(object sender, PaintEventArgs e)
        {
            CheckState cs = checkBox1.CheckState;
            if (cs == CheckState.Indeterminate)
            {
                using (SolidBrush brush = new SolidBrush(checkBox2.BackColor))
                    e.Graphics.FillRectangle(brush, 0, 1, 14, 14);
                e.Graphics.FillRectangle(Brushes.Green, 3, 4, 8, 8);
                e.Graphics.DrawRectangle(Pens.Black, 0, 1, 13, 13);
            }
        }
