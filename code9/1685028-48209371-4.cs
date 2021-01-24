    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace WpfApp1
    {
        public class IntToBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if(value is ColorViewModel)
                {
                    var color = value as ColorViewModel;
                    return new SolidColorBrush(Color.FromRgb(color.Red, color.Green, color.Blue));
                }
    
    
                throw new NotSupportedException();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
