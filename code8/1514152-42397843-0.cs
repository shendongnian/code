    public class SdkController : ApiController
    {
        private HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri(ConfigurationManager.AppSettings["apiUrl"])
        };
        [HttpGet, HttpPost, HttpPut, HttpDelete, Route("v2/{*url}")]
        public HttpResponseMessage PerformRequest(string url)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = null;
                HttpContent requestBody = null;
                string requestUrl = Request.RequestUri.LocalPath.Replace("/SDK/v2/", "");
                string requestMethod = Request.Method.ToString();
                switch (requestMethod)
                {
                    case "GET":
                        response = httpClient.GetAsync(requestUrl).Result;
                        break;
                    case "POST":
                        requestBody = Request.Content;
                        response = httpClient.PostAsync(requestUrl, requestBody).Result;
                        break;
                    case "PUT":
                        requestBody = Request.Content;
                        response = httpClient.PutAsync(requestUrl, requestBody).Result;
                        break;
                    case "DELETE":
                        response = httpClient.DeleteAsync(requestUrl).Result;
                        break;
                }
                return response;
            }
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Internal Server Error"
                };
            }
        }
    }
