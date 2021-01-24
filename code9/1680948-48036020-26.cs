	public class GridLengthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count() == 2 && values[0] is double && values[1] is double)
            {
                double gridActualWidth = (double)values[0];
                double tbMinWidth = (double)values[1];
                if (gridActualWidth >= tbMinWidth * 2)
                {
                    return new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    return parameter.ToString() == "0" ? new GridLength(tbMinWidth) : new GridLength(gridActualWidth - tbMinWidth);
                }
            }
            return new GridLength(1, GridUnitType.Star);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
	
