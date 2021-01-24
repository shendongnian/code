    public abstract class AnItem
    {
        public string GetPaddedString()
        {
            StringBuilder builder = new StringBuilder();
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType != typeof(string))
                    throw new Exception($"Property '{property.Name}' is not a string");
                StringLengthAttribute attribute = property.GetCustomAttributes(typeof(StringLengthAttribute), true).FirstOrDefault() as StringLengthAttribute;
                if (attribute == null)
                    throw new Exception($"StringLength not specified for {property.Name}");
                builder.AppendPadded(property.GetValue(this), attribute.MaximumLength);
            }
            return builder.ToString();
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
