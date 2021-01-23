    public class ConverterBase64ImageSource : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            string base64Image = (string)value;
    
            if (base64Image == null)
                return null;
    
            // Convert base64Image from string to byte-array
            var imageBytes = System.Convert.FromBase64String(base64Image);
    
            // Return a new ImageSource
            return ImageSource.FromStream (() => {return new MemoryStream(imageBytes);});
        }
    
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not implemented as we do not convert back
            throw new NotSupportedException();
        }
    }
