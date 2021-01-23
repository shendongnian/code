    [RoutePrefix("error")]
    public class ErrorController: BaseController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        [Route("{code}/{language}")]
        public HttpResponseMessage Main(string code, string language)
        {
            HttpStatusCode parsedCode;
            var responseMessage = new HttpResponseMessage();
            if (!Enum.TryParse(code, true, out parsedCode))
            {
                parsedCode = HttpStatusCode.InternalServerError;
            }
            responseMessage.StatusCode = parsedCode;
            ...
        }
    }
