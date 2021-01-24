    public class Handler {        
        private TaskCompletionSource<string> _tcs;
        public Task<string> Start(HttpContext context) {
            _tcs = new TaskCompletionSource<string>();
            // shuttles the context to the other parts of the system
            // for processing data
            return _tcs.Task;
        }
        private void Complete(string output) {
            if (_tcs == null)
                throw new Exception("Task has not been started yet");
            // system calls this method, which is then passed back to Startup object.
            _tcs.SetResult(output);
        }
    }
    public void Configure(IApplicationBuilder app) {
        app.Run(async (context) => {
            var output = await new Handler().Start(context);
            await context.Response.WriteAsync(output);
        });
    }
