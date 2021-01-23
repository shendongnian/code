    void SetImageScale()
    {
        SizeF sp = pictureBox1.ClientSize;
        SizeF si = pictureBox1.Image.Size;
        float rp = sp.Width / sp.Height;
        float ri = si.Width / si.Height;
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
