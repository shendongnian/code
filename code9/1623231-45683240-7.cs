    public class FibCalculator
    {
        [Memoized]
        public virtual long Fib(long n)
        {
            if (n < 2L)
                return 1L;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
    var calculator = new Castle.DynamicProxy.ProxyGenerator().CreateClassProxy<FibCalculator>(new Memoizer<long, long>());
    calculator.Fib(5); // 5 invocations
    calculator.Fib(7); // 2 invocations
