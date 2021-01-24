    using System;
    interface IGenericSameTypeFunction
    {
        T Apply<T>(T input);
    }
    
    public class SimpleIdentityFunction : IGenericSameTypeFunction
    {
        public T Apply<T>(T input) => input;
    }
    
    class Test
    {    
        static void F(IGenericSameTypeFunction function)
        {
            Console.WriteLine(function.Apply(1));
            Console.WriteLine(function.Apply("one"));
        }
        
        static void Main()
        {
            F(new SimpleIdentityFunction());
        }
    }
