    public class WebApiController : ApiController
    {        
        public async Task<HttpResponseMessage> Get(string id)
        {
            var bytes = await GetBytesFromDataLayerAsync(id);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new MemoryStream(bytes);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("image/jpeg");
            return result;
        }
        private async Task<byte[]> GetBytesFromDataLayerAsync(string id)
        {
            // put your Oracle logic here
            return ...
        }
    }
