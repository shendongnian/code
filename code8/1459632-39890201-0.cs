    public class LabelVisibilityConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null) return false;
			return values.Any(v =>
			{
				bool? b = v as bool?;
				return b.HasValue && b.Value;
			});
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
