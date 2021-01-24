    public static partial class XmlEnumExtensions
    {
        public static Nullable<TEnum> FromReflectedXmlValue<TEnum>(this string xml) where TEnum : struct, IConvertible, IFormattable
        {
            try
            {
                var obj = (from field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
                           from attr in field.GetCustomAttributes<XmlEnumAttribute>()
                           where attr != null && attr.Name == xml
                           select field.GetValue(null)).SingleOrDefault();
                if (obj != null)
                    return (TEnum)obj;
                 // OK, maybe there is no XmlEnumAttribute override so match on the name.
                return (TEnum)Enum.Parse(typeof(TEnum), xml, false);
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }
        }
    }
