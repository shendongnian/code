    internal class B : A, ICallMe<B>
    {
        B ICallable<B>.CallMe()
        {
            Console.WriteLine("B");
            return this;
        }
    } 
    internal class C : A, ICallMe<C>
    {
        B ICallable<C>.CallMe()
        {
            Console.WriteLine("B");
            return this;
        }
    }
