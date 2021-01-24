    public class PropertyValueConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            var propItem = context.Instance as PropertyItem;
            return propItem != null && TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).CanConvertFrom(context, sourceType)
                || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var propItem = context.Instance as PropertyItem;
            if (propItem != null)
                return TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).ConvertFrom(context, culture, value);
            else
                return base.ConvertFrom(context, culture, value);
        }
    }
