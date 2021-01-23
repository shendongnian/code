    public class ThumbnailToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BitmapImage image = null;
    
            if (value != null)
            {
                StorageItemThumbnail thumbnail = (StorageItemThumbnail)value;
                image = new BitmapImage();
                image.SetSource(thumbnail);
            }
            return (image);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
