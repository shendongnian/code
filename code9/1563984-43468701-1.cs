    public class Type
    {
        private string mark;
        public string name { get; set; }
        private string desc;
        private Bitmap bitmap;
        public BitmapImage img { get; set; }
        public Type(string m, string n, string d, Bitmap mg)
        {
            mark = m;
            name = n;
            desc = d;
            bitmap = mg;
            img = Convert(mg);
        }
        private static BitmapImage Convert(Bitmap bitmap)
        {
            BitmapImage bitmapImage;
            using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
    }
