    [Route("")]
    public class PrerenderController : Controller
    {
        [HttpGet]
        [Produces("text/html")]
        public async Task<string> Get()
        {
            var requestFeature = Request.HttpContext.Features.Get<IHttpRequestFeature>();
            var unencodedPathAndQuery = requestFeature.RawTarget;
            var unencodedAbsoluteUrl = $"{Request.Scheme}://{Request.Host}{unencodedPathAndQuery}";
            var prerenderResult = await Prerenderer.RenderToString(
                hostEnv.ContentRootPath,
                nodeServices,
                new JavaScriptModuleExport("ClientApp/dist/main-server"),
                unencodedAbsoluteUrl,
                unencodedPathAndQuery,
                /* custom data parameter */ null,
                /* timeout milliseconds */ 15 * 1000,
                Request.PathBase.ToString()
            );
            return @"<html>..." + prerenderResult.Html + @"</html>";
        }
    }
