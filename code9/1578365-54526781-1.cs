	class ABitLessConverter : IValueConverter
	{
		private const int REDUCTION_VALUE = 2;
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double intValue = (double)value;
			return intValue > REDUCTION_VALUE ? intValue - REDUCTION_VALUE : value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
