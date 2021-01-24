    public sealed class AbstractionTester
    {
        internal static void Run()
        {
            // The functor here accepts A type but in my original code its just a generic type. 
            // I wanted to keep it simple for this example only 
            Func<ICallMe<A>, bool> func = a =>
            {
                a.CallMe(); //Displays "B"
                return true;
            };
    
            B obj = new B();
            func(obj);
        }
    }
