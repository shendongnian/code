    [ValueConversion(typeof(object), typeof(ImageSource))]
    public class CustomImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource returnSource = null;
    
            if (value != null)
            {
                if (value is byte[])
                {
                    //Your implementation of byte[] to ImageSource
                    returnSource = ...;
                }
                else if (value is Stream)
                {
                    //Your implementation of Stream to ImageSource
                    returnSource = ...;
                } 
                ...          
            }
            return returnSource;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
