    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    
    namespace MyMiddlewareNamespace {
        public class ApiKeyMiddleware {
            private readonly RequestDelegate _next;
            private readonly ILogger _logger;
            private IApiKeyService _service;
    
            public ApiKeyMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IApiKeyService service) {
                _next = next;
                _logger = loggerFactory.CreateLogger<ApiKeyMiddleware>();
                _service = service
            }
    
            public async Task Invoke(HttpContext context) {
                _logger.LogInformation("Handling API key for: " + context.Request.Path);
    
                // do custom stuff here with service      
    
                await _next.Invoke(context);
    
                _logger.LogInformation("Finished handling api key.");
            }
        }
    }
