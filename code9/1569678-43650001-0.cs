	[TypeConverter(typeof (TestClassConverter))]
	public class TestClass
	{
	    public string Property1 { get; set; }
	    public int Property2 { get; set; }
	    public TestClass(string p1, int p2)
	    {
	        Property1 = p1;
	        Property2 = p2;
	    }
	}
	[TypeConverter(typeof (TestClassConverter))]
	public class TestClassConverter : TypeConverter
	{
	    public override bool CanConvertFrom(ITypeDescriptorContext context,
	    Type sourceType)
	    {
	        if (sourceType == typeof(string))
	        {
	            return true;
	        }
	        return base.CanConvertFrom(context, sourceType);
	    }
	    public override object ConvertFrom(ITypeDescriptorContext context,
	     CultureInfo culture, object value)
	    {
	        if (value is string)
	        {
	            return new TestClass("", Int32.Parse(value.ToString()));
	        }
	        return base.ConvertFrom(context, culture, value);
	    }
	    public override object ConvertTo(ITypeDescriptorContext context,
	    CultureInfo culture, object value, Type destinationType)
	    {
	        if (destinationType == typeof(string)) { return "___"; }
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
