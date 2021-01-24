        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string s = values[0] as string;
            if (s==null)
            {
                return (SomeDefaultValue); 
            }
            else
            { 
                Actually do something
            }
        }
