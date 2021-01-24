    public class Bar
    {
        public Task<string> Foo()
        {
            Console.WriteLine("foo called");
            return Task.FromResult("123");
        }
    }
