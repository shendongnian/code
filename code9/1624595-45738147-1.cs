	public class SubtractConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			double[] doubles = values.Cast<double>().ToArray();
			double result = doubles[0];
			for (int i = 1; i < doubles.Length; i++)
			{
				result -= doubles[i];
			}
			return result;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
