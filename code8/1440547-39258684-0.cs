    class Program
    {
        public static T SomeMethod<T>(T paramName)
        {
            return paramName;
        }
        public static U SomeMethod<T, U>(T paramName, Func<T,U> convert)
        {
            return convert(paramName);
        }
        static void Main(string[] args)
        {
            var A=SomeMethod(1033);
            // A = 1033
            var B=SomeMethod(1033, (x) => x.ToString());
            // B = "1033"
        }
    }
