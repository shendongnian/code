    void SetImage(PictureBox pb, Bitmap bmp)
    {
        if (pb.Image != null)
        {
            Bitmap tmp = (Bitmap)pb.Image;
            pb.Image = null;
            tmp.Dispose();
        }
        pb.Image = bmp;
    }
