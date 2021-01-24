    // https://stackoverflow.com/a/45844400
    public class CorsMiddleware
    {
      private readonly RequestDelegate _next;
      public CorsMiddleware(RequestDelegate next)
      {
        _next = next;
      }
      public async Task Invoke(HttpContext context)
      {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
        // Added "Accept-Encoding" to this list
        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
        // New Code Starts here
        if (context.Request.Method == "OPTIONS")
        {
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          await context.Response.WriteAsync(string.Empty);
        }
        // New Code Ends here
        await _next(context);
      }
    }
