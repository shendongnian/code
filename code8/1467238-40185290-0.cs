    private Point mouseDown;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                mouseDown = new Point(e.X, e.Y);
                _selection = new Rectangle(mouseDown, new Size());
            }
        }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selecting)
            {
                Point mousePos = new Point(e.X, e.Y);
                if(mousePos.X < 0)
                {
                    mousePos.X = 0;
                }
                if(mousePos.X >= pictureBox1.Width)
                {
                    mousePos.X = pictureBox1.Width - 1;
                }
                if(mousePos.Y < 0)
                {
                    mousePos.Y = 0;
                }
                if (mousePos.Y >= pictureBox1.Height)
                {
                    mousePos.Y = pictureBox1.Height - 1;
                }
                _selection.X = Math.Min(mouseDown.X, mousePos.X);
                _selection.Y = Math.Min(mouseDown.Y, mousePos.Y);
                _selection.Width = Math.Abs(mousePos.X - mouseDown.X);
                _selection.Height = Math.Abs(mousePos.Y - mouseDown.Y);
                // Redraw the picturebox:
                pictureBox1.Invalidate();
            }
        }
