    using System;
    using System.Reflection;
    namespace ExtensionsNamespace
    {
        public static class Extensions
        {
            public static TAttribute GetAttribute<TAttribute>(Enum value) where TAttribute : Attribute
            {
                return value.GetType()
                    .GetMember(value.ToString())[0]
                    .GetCustomAttribute<TAttribute>();
            }
        }
    }
