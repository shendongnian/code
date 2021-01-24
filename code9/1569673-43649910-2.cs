    public class CrazyClassTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var casted = value as string;
            return casted != null
                ? new CrazyClass(casted.ToCharArray())
                : base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var casted = value as CrazyClass;
            return destinationType == typeof (string) && casted != null
                ? String.Join("", casted.Charray)
                : base.ConvertTo(context, culture, value, destinationType);
        }
    }
