    public class MyOwinFileClient
    {
        private readonly Owin.Client.WebApiClient webApiClient;
        // constructor:
        public MyOwinFileClient()
        {
            this.webApiClient = new Owin.Client.WebApiClient(... url);
        }
        // the function to get the stream:
        public async Task<Stream> GetFileStream(Guid fileId)
        {
            HttpClient myClient = ...
            string requestStreamUri = @"test\GetFileStream?fileId=" + fileId.ToString("N");
            HttpResponseMessage responseMessage = await httpClient.GetAsync(requestStreamUri)
                .ConfigureAwait(false);
            // throw exception if not Ok:
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new System.Net.Http.HttpRequestException($"{response.StatusCode} [{(int)response.StatusCode}]: {content}");
            }
            // if here: success: convert response as stream:
            Stream stream = await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false);
            return stream;
        }
    }
