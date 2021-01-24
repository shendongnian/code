    using System.ComponentModel;
    ...
    public class IPAddressConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(
            ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return IPAddress.Parse((string)value);
        }
    }
