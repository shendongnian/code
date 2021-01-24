    public abstract class AnItem
    {
        private static int GetLength(PropertyInfo property)
        {
            StringLengthAttribute attribute = property.GetCustomAttributes(typeof(StringLengthAttribute), true).FirstOrDefault() as StringLengthAttribute;
            if (attribute == null)
                throw new Exception($"StringLength not specified for {property.Name}");
            return attribute.MaxLength();
        }
        private string GetPropertyValue(PropertyInfo property)
        {
            if (property.PropertyType == typeof(string))
                return property.GetValue(this);
            else if (property.PropertyType == typeof(int))
                return property.GetValue(this).ToString();
            else
                throw new Exception($"Property '{property.Name}' is not a supported type");
        }
        private static void SetPropertyValue(object item, PropertyInfo property, string value)
        {
            if (property.PropertyType == typeof(string))
                property.SetValue(item, value, null);
            else if (property.PropertyType == typeof(int))
                property.SetValue(item, int.Parse(value), null);
            else
                throw new Exception($"Property '{property.Name}' is not a supported type");
        }
        public string GetPaddedString()
        {
            StringBuilder builder = new StringBuilder();
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo property in properties)
                builder.AppendPadded(GetPropertyValue(property), GetLength(property));
            return builder.ToString();
        }
        public static T CreateFromPaddedString<T>(string paddedString) where T : AnItem, new()
        {
            T item = new T();
            int offset = 0;
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                int length = GetLength(property);
                if (offset + length > paddedString.Length)
                    throw new Exception("The string is too short");
                SetPropertyValue(item, property, paddedString.Substring(offset, length)));
                offset += length;
            }
            if (offset < paddedString.Length)
                throw new Exception("The string is too long");
            return item;
        }
    }
    public class MyItem : AnItem
    {
        [StringLength(1)]
        public string ProductCode { get; set; }
        [StringLength(12)]
        public string ApplicantFirstName { get; set; }
        [StringLength(1)]
        public string ApplicantMiddleInitial { get; set; }
        [StringLength(1)]
        public string Partner { get; set; }
        [StringLength(8)]
        public string Employee { get; set; }
    }
