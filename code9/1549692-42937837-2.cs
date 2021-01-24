	public class SelectedToFontAttributeConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((Boolean)value)
					return FontAttributes.Bold;
				else
					return FontAttributes.None;
			}
			return FontAttributes.None;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
