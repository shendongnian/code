    using System;
    using System.Reflection;
    public class Test
    {
        static void Main()
        {
            MethodInfo method = (string).GetMethod(“IndexOf”, new Type[]{typeof(char)});
        
            Func<char, int> converted = (Func<char, int>) 
    Delegate.CreateDelegate(typeof(Func<char, int>), “Hello”, method);
        
            Console.WriteLine(converted(‘l’));
            Console.WriteLine(converted(‘o’));
            Console.WriteLine(converted(‘x’));
        }
    }
