    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Cursor = ImageArea(pictureBox1).Contains(e.Location) ?
                                                    Cursors.Hand : Cursors.Default;
    }
    Rectangle ImageArea(PictureBox pbox)
    {
        Size si = pbox.Image.Size;
        Size sp = pbox.ClientSize;
        float ri = si.Width / si.Height;
        float rp = sp.Width / sp.Height;
        if (rp > ri)
        {
            int width = si.Width * sp.Height / si.Height;
            int left = (sp.Width - width) / 2;
            return = new Rectangle(left, 0, width, sp.Height);
        }
        else
        {
            int height = si.Height * sp.Width / si.Width;
            int top = (sp.Height - height) / 2;
            return = new Rectangle(0, top, sp.Width, height);
        }
    }
