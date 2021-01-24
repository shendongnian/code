    public class MyEnumConverter : IValueConverter
    {
        public object ConvertTo (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is DropoffContact))
                return value;
            switch (DropoffContact)value) {
            case DropoffContact.Display:
                return "Some string representation"
            default:
                return value;
            }
        }
        public void ConvertFrom (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            thrown new NotImplementedException();
        }
    }
