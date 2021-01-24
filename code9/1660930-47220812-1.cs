    private void PaintRedRectangle(int i)
        {
            try
            {
                ci.Location = new Point(lRectangle[i].X, lRectangle[i].Y);
                ci.Size = new Size(10, 10);
                ci.BackColor = Color.Red;
                ci.BringToFront();
                ci.Show();
            }
            catch(ObjectDisposedException)
            {
                ci = new InvisibleFrame();
                PaintRedRectangle(i);
            }
        }
