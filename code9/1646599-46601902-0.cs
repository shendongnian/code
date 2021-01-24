    public class MySuperAmazingMiddleware
    {
        private readonly RequestDelegate _next;
    
        public MySuperAmazingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public Task Invoke(HttpContext context)
        {
            var mySuperAmazingObject = GetSuperAmazingObject();
            context.Items.Add("SuperAmazingObject", mySuperAmazingObject );
    
            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
