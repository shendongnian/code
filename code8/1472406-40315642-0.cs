    using System;
    
    namespace StackOverflowSnippets
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(DoSomething<Int32>(new CreateSumOf(12, 30)));
                Console.ReadLine();
            }
    
            public static T DoSomething<T>(Function<T> f)
            {
                try
                {
                    return f.RunMe();
                }
                catch(Exception)
                {
                    // Handle the Exception and Ok
                }
    
                throw new InvalidOperationException();
            }
    
            public class CreateSumOf : Function<Int32>
            {
                private Int32 _a;
                private Int32 _b;
    
                public CreateSumOf(Int32 a, Int32 b)
                {
                    _a = a;
                    _b = b;
                }
    
                public override Int32 RunMe()
                {
                    return (_a + _b);
                }
            }
            public abstract class Function<T>
            {
                public abstract T RunMe();
            }
        }
    }
