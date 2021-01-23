    // Helper to enable request stream rewinds
    using Microsoft.AspNetCore.Http.Internal;
    [...]
    public class EnableBodyRewind : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var bodyStr = "";
            var req = context.HttpContext.Request;
            // Allows using several time the stream in ASP.Net Core
            req.EnableRewind(); 
            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader 
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }
            // Rewind, so the core is not lost when it looks the body for the request
            req.Body.Position = 0;
            // Do whatever work with bodyStr here
        }
    }
    public class SomeController : Controller
    {
        [HttpPost("MyRoute")]
        [EnableBodyRewind]
        public IActionResult SomeAction([FromBody]MyPostModel model )
        {
            // play the body string again
        }
    }
