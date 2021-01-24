    public static partial class XmlEnumExtensions
    {
        public static TEnum FromReflectedXmlValue<TEnum>(this string xml) where TEnum : struct, IConvertible, IFormattable
        {
            // Adapted from https://stackoverflow.com/questions/35294530/c-sharp-getting-all-enums-value-by-attribute
            var obj = (from field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
                       from attr in field.GetCustomAttributes<XmlEnumAttribute>()
                       where attr != null && attr.Name == xml
                       select field.GetValue(null)).SingleOrDefault();
            if (obj != null)
                return (TEnum)obj;
            // OK, maybe there is no XmlEnumAttribute override so match on the name.
            return (TEnum)Enum.Parse(typeof(TEnum), xml, false);
        }
    }
