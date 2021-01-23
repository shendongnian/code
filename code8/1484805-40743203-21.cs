     public class boolToVisibilityConverter : IValueConverter
    {
        public bool isInverseReq { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool val = (bool)value;
            if(isInverseReq)
            {
                if (val)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
            else
            {
                if (val)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
