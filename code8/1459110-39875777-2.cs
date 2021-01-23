    public class MyTypeConverter : TypeConverter
    {
        Dictionary<int, string> standardValues;
        public MyTypeConverter2()
        {
            //Get the list from where you want
            standardValues = new Dictionary<int, string> {
                { 1, "1 - On"}, { 2, "2 - Off"}, { 3, "3 - Unknown" }};
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context,
            Type destinationType)
        {
            if (destinationType == typeof(int))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, 
            System.Globalization.CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (stringValue != null && standardValues.ContainsValue(stringValue))
                return standardValues.Where(x => x.Value == stringValue)
                    .FirstOrDefault().Key;
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, 
            System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null)
            {
                var valueType = value.GetType();
                if (valueType == typeof(int))
                    return standardValues[(int)value];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(standardValues.Select(x=>x.Key).ToList());
        }
    }
