    using System;
    
    namespace TEST
    {
        public static class Extensions
        {
            public static object Invoke(this object obj, string method, Type[] types, object[] args)
            {
                return obj?.GetType().GetMethod(method, types)?.Invoke(obj, args);
            }
    
            public static object Invoke(this object obj, string method, params object[] args)
            {
                return obj.Invoke(method, new Type[0], args);
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine(4.Invoke("ToString"));
            }
        }
    }
