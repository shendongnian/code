     public class CorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CorsMiddleware> _logger;
        public CorsMiddleware(RequestDelegate next, IMemoryCache cache, ILogger<CorsMiddleware> logger)
        {
            _next = next;
            _cache = cache;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, IAdministrationApi adminApi)
        {
            if (context.Request.Headers.ContainsKey(CorsConstants.Origin) || context.Request.Headers.ContainsKey("origin"))
            {
                if (!context.Request.Headers.TryGetValue(CorsConstants.Origin, out var origin))
                {
                    context.Request.Headers.TryGetValue("origin", out origin);
                }
                bool isAllowed;
                // Getting origin from DB to check with one from request and save it in cache 
                var result = _cache.GetOrCreateAsync(origin, async cacheEntry => await adminApi.DoesExistAsync(origin));
                isAllowed = result.Result.Result;
                if (isAllowed)
                {
                    context.Response.Headers.Add(CorsConstants.AccessControlAllowOrigin, origin);
                    context.Response.Headers.Add(
                        CorsConstants.AccessControlAllowHeaders,
                        $"{HeaderNames.Authorization}, {HeaderNames.ContentType}, {HeaderNames.AcceptLanguage}, {HeaderNames.Accept}");
                    context.Response.Headers.Add(CorsConstants.AccessControlAllowMethods, "POST, GET, PUT, PATCH, DELETE, OPTIONS");
                    if (context.Request.Method == "OPTIONS")
                    {
                        _logger.LogInformation("CORS with origin {Origin} was handled successfully", origin);
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        return;
                    }
                    await _next(context);
                }
                else
                {
                    if (context.Request.Method == "OPTIONS")
                    {
                        _logger.LogInformation("Preflight CORS request with origin {Origin} was declined", origin);
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        return;
                    }
                    _logger.LogInformation("Simple CORS request with origin {Origin} was declined", origin);
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;
                }
            }
            await _next(context);
        }
