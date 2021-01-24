    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    .
    .
    .
    
    public class MyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;
            if (v == 100) return Visibility.Visible;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not really necesary...
            return 0.0;
        }
    }
