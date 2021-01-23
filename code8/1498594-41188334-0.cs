    public class MyClass
    {
        public static string Function1<T>()
        {
            return typeof(T).FullName;
        }
        public static string Function2<T>() where T : IEnumerable
        {
            return typeof(T).FullName;
        }
    }
