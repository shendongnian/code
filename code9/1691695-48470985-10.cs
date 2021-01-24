    public class LogMiddleware {
        private readonly RequestDelegate _next;
    
        public LogMiddleware(RequestDelegate next) {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context, IMyLoggingModel db) {
            await WriteRequestToLog(context.Request, db);
            await _next.Invoke(context);
        }
    
        private async Task WriteRequestToLog(HttpRequest request, IMyLoggingModel db) {
            using (db) {
                db.Log.Add(new Log {
                    Path = request.Path,
                    Query = request.QueryString.Value
                });
                await db.SaveChangesAsync();
            }
        }
    }
