        using (Bitmap bm = new Bitmap(imgBox.Image))
        {
            using (Image<Gray, Single> image = new Image<Gray, Single>(bm))
            {
                EmguImage = EmguImage.Not();
                imgBox.Image.Dispose();
                imgBox.Image = EmguImage.Bitmap;
            }
        }
