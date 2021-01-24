    Rectangle ImageArea(PictureBox pbox)
    {
        Size si = pbox.Image.Size;
        Size sp = pbox.ClientSize;
        if (pbox.SizeMode == PictureBoxSizeMode.StretchImage) return pbox.ClientRectangle;
        if (pbox.SizeMode == PictureBoxSizeMode.Normal ||
           pbox.SizeMode == PictureBoxSizeMode.AutoSize) return new Rectangle(Point.Empty, si);
        if (pbox.SizeMode == PictureBoxSizeMode.CenterImage)
            return new Rectangle(new Point( (sp.Width - si.Width) / 2,
                                (sp.Height - si.Height) / 2), si); 
        //  PictureBoxSizeMode.Zoom
        float ri = 1f * si.Width / si.Height;
        float rp = 1f * sp.Width / sp.Height;
        if (rp > ri)
        {
            int width = si.Width * sp.Height / si.Height;
            int left = (sp.Width - width) / 2;
            return new Rectangle(left, 0, width, sp.Height);
        }
        else
        {
            int height = si.Height * sp.Width / si.Width;
            int top = (sp.Height - height) / 2;
            return new Rectangle(0, top, sp.Width, height);
        }
    }
