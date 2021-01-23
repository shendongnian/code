        public void photocrop(int x, int y, int w, int h)
        {
                string filePath = Path.Combine(Server.MapPath("/images/users/temp"), "MyImage.jpg");
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(
                    Convert.ToInt32(x),
                    Convert.ToInt32(y),
                    Convert.ToInt32(w),
                    Convert.ToInt32(h));
                Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                }
                cropFilePath = Path.Combine(Server.MapPath("~/images/users"), fileNameOk);
                bitMap.Save(cropFilePath);
       }
