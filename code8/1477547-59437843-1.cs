    [Route("[controller]/[action]")]
    public class MyController : ControllerBase
    {
        // ...
        [HttpPost]
        public async void TheAction()
        {
            try
            {
                HttpContext.Request.EnableBuffering();
                Request.Body.Position = 0;
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    var task = stream
                        .ReadToEndAsync()
                        .ContinueWith(t => {
                            var res = t.Result;
                            // TODO: Handle the post result!
                        });
                    // await processing of the result
                    task.Wait();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to handle post!");
            }
        }
