    public class FooMiddleware
    {
        public FooMiddleware(RequestDelegate next, List<string> list)
        {
            _next = next;
        }
    }
