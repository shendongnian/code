    public class MyAttribute : Attribute
    {
        public static string GetAttribute(MemberInfo m)
        {
            var displayName =(DisplayNameAttribute)Attribute
                                   .GetCustomAttribute(m, typeof(DisplayNameAttribute));
            return displayName.DisplayName;
        }
    }
