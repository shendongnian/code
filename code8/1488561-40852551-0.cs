             if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                  string pic = openFileDialog1.FileName;
                  string filePath;
                  string newfilepath;//here you should assign your newfilepath
                  filePath = pic;
                  Bitmap bmp = null;
           
                  using (var stream = File.OpenRead(filePath))
                        {
                         bmp = (Bitmap)Bitmap.FromStream(stream);
                         bmp.Save(newfilepath, System.Drawing.Imaging.ImageFormat.Jpeg);//here you can change the format i.e. bmp,jpg,png etc.
                        }
               }
        
