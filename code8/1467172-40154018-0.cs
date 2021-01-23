    public class EnumAttribute : Attribute
    {
        public EnumAttribute(string key)
        {
            Key = key;
        }
        public string Key { get; }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
