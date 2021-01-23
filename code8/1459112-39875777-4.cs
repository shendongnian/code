    public class MyTypeConverter : TypeConverter
    {
        Dictionary<int, string> values;
        public MyTypeConverter()
        {
            values = new Dictionary<int, string> { { 1, "1 - On" }, { 2, "2 - Off" }, { 3, "3 - Unknown" } };
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value != null && values.ContainsValue(value.ToString()))
                return values.Where(x => x.Value == value.ToString()).FirstOrDefault().Key;
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null && value.GetType() == typeof(int))
                return values[(int)value];
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(values.Keys);
        }
    }
