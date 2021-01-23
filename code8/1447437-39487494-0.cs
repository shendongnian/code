    void loadImage(PictureBox pbox, string file)
    {
        if (pbox.Image != null)
        {
            var dummy = pbox.Image;
            pbox.Image = null;
            dummy.Dispose();
        }
        if (File.Exists(file)) pbox.Image = Image.FromFile(file);
    }
