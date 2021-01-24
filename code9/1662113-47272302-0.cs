    class TestException : Exception
    {
    }
    class TestException2:Exception
    {
    }
    class foo : ExceptionHandler<TestException> { }
    class bar : ExceptionHandler<TestException2> { }
    public interface ExceptionHandler<out T> where T : Exception
    { }
    class Program
    {
        static void Main(string[] args)
        {
            List<ExceptionHandler<Exception>> a = new List<ExceptionHandler<Exception>>();
            a.Add(new foo());
            a.Add(new bar());
        }
    }
