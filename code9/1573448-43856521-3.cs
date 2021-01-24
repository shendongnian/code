    namespace PasswordBoxMVVM
    {
        class PasswordLengthToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int length = (int)value;
                Color output = Colors.Red;
    
                if (length >= 0 && length < 5)
                    output = Colors.Red;
    
                else if (length >= 5 && length < 6)
                    output = Colors.Orange;
    
                else if (length >= 6 && length < 7)
                    output = Colors.Yellow;
    
                else if (length >= 7 && length < 8)
                    output = Colors.LightGreen;
    
                else if (length >= 8)
                    output = Colors.Green;
    
                return output;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
