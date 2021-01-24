    [TypeConverter(typeof(StringArrayConverter))]
    [ConfigurationProperty("test")]
    public string[] Test
    {
        get { return (string[])base["test"]; }
        set { base["test"] = value; }
    }
    public class StringArrayConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string[]);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return ((string)value).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return value.JoinStrings();
        }
    }
