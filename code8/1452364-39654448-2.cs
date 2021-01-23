    using System;
    using System.IO;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media.Imaging;
    ...
    public class ImageConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, string language)
        {
            var bitmap = new BitmapImage();
            var buffer = value as byte[];
            if (buffer != null)
            {
                using (var stream = new InMemoryRandomAccessStream())
                {
                    stream.AsStreamForWrite().Write(buffer, 0, buffer.Length);
                    stream.Seek(0);
                    bitmap.SetSource(stream);
                }
            }
            return bitmap;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
