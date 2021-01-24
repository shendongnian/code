	public class MyCustomIntConverter  : Int32Converter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value != null && value is string)
			{
				string stringValue = value as string;
				if(stringValue == "disabled")
				{
					return -1;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
