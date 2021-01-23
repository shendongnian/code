    public static class MyClass_Extensions
    {
        public static string StaticMethod1(this object obj)
        {
            return obj?.ToString();
        }
        public static string StaticMethod2(this IEnumerable obj)
        {
            return obj?.ToString();
        }
    }
