	class MyAwesomeProgressConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return ((double)values[0]).ToString("f2") + "/" + ((double)values[1]).ToString("f2");
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			Enumerable.Repeat(DependencyProperty.UnsetValue, targetTypes.Length).ToArray()
		}
	}
