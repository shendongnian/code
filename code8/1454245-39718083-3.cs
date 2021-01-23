    public class UIntTypeConverter : TypeConverter
	{
		public override object ConvertFromInvariantString(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;
			return Uint32.Parse(value, CultureInfo.InvariantCulture);
		}
    }
