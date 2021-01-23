    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    namespace MyNamespace.HttpClient
    {
    public static class HttpClient
    {
        private static readonly System.Net.Http.HttpClient NetHttpClient = new System.Net.Http.HttpClient();
        static HttpClient()
        {}
        public static async System.Threading.Tasks.Task<string> ExecuteMethod(string targetAbsoluteUrl, string methodName, List<KeyValuePair<string, string>> headers = null, string content = null, string contentType = null)
        {
            var httpMethod = new HttpMethod(methodName.ToUpper());
            var requestMessage = new HttpRequestMessage(httpMethod, targetAbsoluteUrl);
            if (!string.IsNullOrWhiteSpace(content) || !string.IsNullOrWhiteSpace(contentType))
            {
                var contentBytes = Encoding.UTF8.GetBytes(content);
                requestMessage.Content = new ByteArrayContent(contentBytes);
                headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content-type", contentType)
                };
            }
            headers?.ForEach(kvp => { requestMessage.Headers.Add(kvp.Key, kvp.Value); });
            var response = await NetHttpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
    }
    }
