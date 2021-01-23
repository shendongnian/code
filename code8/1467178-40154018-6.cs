    // This one is to indicate the format of the keys in your settings
    public class EnumAttribute : Attribute
    {
        public EnumAttribute(string key)
        {
            Key = key;
        }
        public string Key { get; }
    }
    // This one is to give an id to your enum field
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
