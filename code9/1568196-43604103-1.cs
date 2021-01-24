    class RangeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int age = (int)value;
            Brush output = Brushes.Transparent;
            if (age >= 0 && age <= 4)
            {
                output = Brushes.Red;
            }
            else if (age >= 5 && age <= 10)
            {
                output = Brushes.Green;
            }
            else if (age >= 11 && age <= 14)
            {
                output = Brushes.Blue;
            }
            else if (age >= 15 && age <= 18)
            {
                output = Brushes.Yellow;
            }
            else if (age >= 18 && age <= 23)
            {
                output = Brushes.Orange;
            }
            return output;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
