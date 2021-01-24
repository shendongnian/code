    public static class EnumExtensions
    {
        public static IEnumerable<string> GetStringValues<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<Enum>()
                .Select(e => e.GetStringValue())
                .ToList();
        }
        public static IEnumerable<string> GetStringValuesOfType(Enum value)
        {
            return Enum.GetValues(value.GetType())
                .Cast<Enum>()
                .Select(e => e.GetStringValue())
                .ToList();
        }
		
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            string stringValue = null;
            if (attributes.Length > 0)
            {
                stringValue = attributes[0].Value;
            }
            return stringValue;
        }
    }
