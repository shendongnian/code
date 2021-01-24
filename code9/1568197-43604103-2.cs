    class RangeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int age = (int)value;
            string output = "";
            if (age >= 0 && age <= 4)
            {
                output = "Baby";
            }
            else if (age >= 5 && age <= 10)
            {
                output = "Kid";
            }
            else if (age >= 11 && age <= 14)
            {
                output = "Children";
            }
            else if (age >= 15 && age <= 18)
            {
                output = "Teens";
            }
            else if (age >= 18 && age <= 23)
            {
                output = "Adult";
            }
            return output;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
