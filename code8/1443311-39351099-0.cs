    public class ByteToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var bytes = value as byte[];
            if (bytes == null)
                throw new ArgumentNullException(nameof(value));
    
            return bytes.ToBitmapImage();
        }
    
        public static BitmapImage ToBitmapImage(this byte[] byteArrayIn)
        {
    
            MemoryStream stream = new MemoryStream();
            stream.Write(byteArrayIn, 0, byteArrayIn.Length);
            stream.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            BitmapImage returnImage = new BitmapImage();
            returnImage.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            returnImage.StreamSource = ms;
            returnImage.EndInit();
    
            return returnImage;
    
    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
