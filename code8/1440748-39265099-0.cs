	public sealed class InvertedBooleanConverter : IValueConverter
	{
		public Object Convert( Object value, Type targetType, Object parameter, CultureInfo culture )
		{
			if ( value is Boolean )
			{
				return (Boolean)value ? false : true;
			}
			return null;
		}
		public Object ConvertBack( Object value, Type targetType, Object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}
	}
