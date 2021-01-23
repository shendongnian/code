    [ValueConversion(typeof(ErrorLevel), typeof(Brush))]
    public class TypeToColourConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (!(value is ErrorLevel))
                return Brushes.Gray;
            if (!(parameter is ErrorColors))
                return Brushes.Gray;
            var lvl = (ErrorLevel)value;
            var currentColor = (ErrorColors)parameter;
            switch (lvl)
            {
                case ErrorLevel.Information:
                    return currentColor.INFORMATION;
                case ErrorLevel.Warning:
                    return currentColor.WARNING;
                case ErrorLevel.Error:
                    return currentColor.ERROR;
            }
            return Brushes.Gray;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
---
    public class ErrorColors
    {
        public SolidColorBrush ERROR { get; set; }
        public SolidColorBrush WARNING { get; set; }
        public SolidColorBrush INFORMATION { get; set; }
    }
