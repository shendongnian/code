    public class StringToSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            double size;
            if(double.TryParse(value.ToString, out size))
            {
                //this is a double
                return size;            
            }    
            // its a named size, so convert the named size to enum
           NamedSize namedSize;
           if (Enum.TryParse(value.ToString, true, out namedSize))
           {
                return Device.GetNamedSize(NamedSize.Default, typeof(Label));
           }    
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
