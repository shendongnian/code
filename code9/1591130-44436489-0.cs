    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace Test
    {
        public class Wrap<T>
        {
            public T Contents { get; set; }
    
            public object DeepUnwrap()
            {
                var wrapped = this;
                var hello = wrapped.Unwrap();
    
                if (hello != null)
                {
                    var type = hello.GetType();
    
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Wrap<>))
                        return ((dynamic)hello).DeepUnwrap();
                }
    
                return hello;
            }
    
        }
    
        public static class WrapHelpers
        {
            public static Wrap<T> Wrap<T>(this T contents)
            {
                return new Wrap<T> { Contents = contents };
            }
            public static T Unwrap<T>(this Wrap<T> wrapped)
            {
                return wrapped.Contents;
            }
    
            public static object FullUnwrap<T>(this Wrap<T> wrapped)
            {
                var hello = wrapped.DeepUnwrap();
    
                return hello;
            }
    
            //NOP
            public static T Unwrap<T>(this T contents)
            {
                return contents;
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                string s = "ssss";
                var wrappedString = s.Wrap().Wrap().Wrap();
                Console.WriteLine(wrappedString.FullUnwrap());
                Console.ReadLine();
            }
        }
    }
     
