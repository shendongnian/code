    public static class ExtensionClass
    {
        public static TAttribute GetAttribute<TAttribute>(Enum value) where TAttribute : Attribute
        {
            return value.GetType()
               .GetMember(value.ToString())[0]
               .GetCustomAttribute<TAttribute>();
        }
    }
