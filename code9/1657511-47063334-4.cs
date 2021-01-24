    public class WhateverThisIsCalledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Insert type- and sanity-checks here
            double val = (double)values[0];
            FrameworkElement callingElement = (FrameworkElement)values[1];
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
