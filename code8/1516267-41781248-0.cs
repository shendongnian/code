        Bitmap ChangeToColor(Bitmap bmp, Color c)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            using (Graphics g = Graphics.FromImage(bmp2))
            {
                float tr = c.R / 255f;
                float tg = c.G / 255f;
                float tb = c.B / 255f;
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                  {
                    new float[] { tr, 0, 0, 0, 0},
                    new float[] {0,  tg,  tb, 0, 0},
                    new float[] {0, 0,  tb, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                  });
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);
                g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp2;
        }
