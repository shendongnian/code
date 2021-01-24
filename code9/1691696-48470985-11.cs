    public class LogMiddleware {
        private readonly RequestDelegate _next;
    
        public LogMiddleware(RequestDelegate next) {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context) {
            await WriteRequestToLog(context);
            await _next.Invoke(context);
        }
    
        private async Task WriteRequestToLog(HttpContext context) {
            var request = context.Request;
            using (var db = context.RequestServices.GetService<IMyLoggingModel>()) {
                db.Log.Add(new Log {
                    Path = request.Path,
                    Query = request.QueryString.Value
                });
                await db.SaveChangesAsync();
            }
        }
    }
