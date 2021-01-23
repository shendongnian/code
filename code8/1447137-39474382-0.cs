    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Rectangle ImgArea = Rectangle.Empty;
        Size si = pictureBox1.Image.Size;
        Size sp = pictureBox1.ClientSize;
        float ri = si.Width / si.Height;
        float rp = sp.Width / sp.Height;
        if (rp > ri)
        {
            int width = si.Width * sp.Height / si.Height;
            int left = (sp.Width - width) / 2;
            ImgArea = new Rectangle(left, 0, width, sp.Height);
        }
        else
        {
            int height = si.Height * sp.Width / si.Width;
            int top = (sp.Height - height) / 2;
            ImgArea = new Rectangle(0, top, sp.Width, height);
        }
            pictureBox1.Cursor = ImgArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
    }
