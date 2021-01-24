    class MultiValConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                if (values[0].ToString() == values[1].ToString())
                {
                    return "...";//put your logic here i.e. substring(0,30);
                }
            }
            return values[0];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }  
