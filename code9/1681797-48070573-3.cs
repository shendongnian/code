    public class GridProportionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count() == 2 && values[0] is ICollection && values[1] is double && ((ICollection)values[0]).Count > 0)
            {
                ICollection collection = (ICollection)values[0];
                double windowHeight = (double)values[1];
                if (windowHeight < 350)
                {
                    return new GridLength(1, GridUnitType.Star);
                }
                return new GridLength(collection.Count, GridUnitType.Star);
            }
            return new GridLength(1, GridUnitType.Star);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
	
