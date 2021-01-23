    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    
    namespace WpfApp1
    {
        public class ByteArrayToImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null) return null;
    
                //Convert the byte[] to a BitmapImage
                BitmapImage img = new BitmapImage();
                MemoryStream ms = new MemoryStream((byte[])value);
                img.BeginInit();
                img.StreamSource = ms;
                img.EndInit();
    
                return img;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
