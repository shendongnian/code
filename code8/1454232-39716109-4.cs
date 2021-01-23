    public class MapAttribute : Attribute
    {
        public MapAttribute(string fieldKey)
        {
            this.Field = fieldKey;
        }
        public string Field { get; private set; }
        public PropertyInfo Property { get; set; }
        public void SetValue(Question question, string value)
        {
            this.Property.SetValue(question, value);
        }
    }
