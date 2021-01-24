    using System;
    
    public class Foo<TFirst, TSecond> {}
    
    class Test
    {
        static void Main()
        {
            var type = typeof(Foo<,>);
            Console.WriteLine($"Full name: {type.FullName}");
            Console.WriteLine("Type argument names:");
            foreach (var arg in type.GetGenericArguments())
            {
                Console.WriteLine($"  {arg.Name}");
            }
        }
    }
