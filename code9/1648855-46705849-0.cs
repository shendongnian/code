        public void GreyScaleConversion()
        {
            //read image
            Bitmap bmp = global::Ribbon.Properties.Resources.Device;
    
            //load original image in picturebox1
            pictureBox1.Image = global::Ribbon.Properties.Resources.Device;
    
            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;
    
            //color of pixel
            Color p;
    
            //grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);
    
                    //extract pixel component A
                    int a = p.A;
                    
                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, 155, 155, 155));
                }
            }
    
            //load grayscale image in picturebox2
            pictureBox2.Image = bmp;
        }
