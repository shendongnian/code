      private Bitmap SetImage(){
          pictureBox1.Image = GetImageFromPath(ImagePath)
      }
      private Bitmap GetImageFromPath(string Path)
      {
            using (StreamReader streamReader = new StreamReader(Path))
            {
                using (Bitmap tmpBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream))
                {
                    return tmpBitmap;
                }
            }
       }
