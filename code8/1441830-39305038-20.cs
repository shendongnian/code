    void GetImageScaleData(PictureBox pbox)
    {
        SizeF sp = pbox.ClientSize;
        SizeF si = pbox.Image.Size;
        float rp = sp.Width / sp.Height;   // calculate the ratios of
        float ri = si.Width / si.Height;   // pbox and image
        if (rp > ri)
        {
            zoom = sp.Height / si.Height;
            float width = si.Width * zoom;
            float left = (sp.Width - width) / 2;
            ImgArea = new RectangleF(left, 0, width, sp.Height);
        }
        else
        {
            zoom = sp.Width / si.Width;
            float height = si.Height * zoom;
            float top = (sp.Height - height) / 2;
            ImgArea = new RectangleF(0, top, sp.Width, height);
        }
    }
