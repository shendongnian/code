	public class MultiBooleanToVisibilityConverter : IMultiValueConverter
	{
		
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values.OfType<bool>().All(b => b == true))// your logic here
				return Visibility.Visible;
			else
				return Visibility.Collapsed;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException("One Way only");
		}
	}
