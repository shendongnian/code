    public static TResult Timed<T1, /*T2, etc*/TResult>(out long duration, Func<T1, /*T2, etc*/TResult> func, T1 arg1/*T2 arg2, etc*/)
    {
        //start timing
        var t0 = DateTime.Now;
        var result = func(arg1);
        //end timing
        duration = (long)DateTime.Now.Subtract(t0).TotalMilliseconds;
        return result;
    }
        
    public int Factorial(int n)
    {
        return n > 0 ? n * Factorial(n - 1) : 1;
    }
    public int Fibonacci(int n)
    {
        return n > 1 ? Fibonacci(n - 2) + Fibonacci(n - 1) : n;
    }
    public static void Main()
    {
        var program = new Program();
        
        long duration;
        
        var _12bang = Timed(out duration, program.Factorial, 12);
        
        Console.WriteLine("{0}! = {1} in {2} ms", 12, _12bang, duration);
        
        var fib31 = Timed(out duration, program.Fibonacci, 31);
        
        Console.WriteLine("Fib {0} = {1} in {2} ms", 31, fib31, duration);
        
    }
