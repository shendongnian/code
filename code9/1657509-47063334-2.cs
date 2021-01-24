    public class WhateverThisIsCalledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse(values[0].ToString(), out double val);
            FrameworkElement callingElement = values[1] as FrameworkElement;
            if (val >= 1)
            {
                return callingElement.FindResource("PrimaryHueMidBrush");
            }
            if (val >= 0.5)
            {
                return Brushes.MediumVioletRed;
            }
            
            return Brushes.Transparent;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return Enumerable.Repeat(DependencyProperty.UnsetValue, targetTypes.Length).ToArray();
        }
    }
