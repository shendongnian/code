    public class MyHandler : HttpTaskAsyncHandler {
        public override async Task ProcessRequestAsync(HttpContext context) {
            var result = await Code.Helpers.Email.Sendgrid.Queue.Process();
            if (result.Success) {
                //..other code
            }
        }
    }
