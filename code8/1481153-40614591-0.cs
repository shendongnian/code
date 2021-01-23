    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       
        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next.Invoke(context);
            } 
            catch (Exception e) 
            {
                // Handle exception
            }
        }
    }
