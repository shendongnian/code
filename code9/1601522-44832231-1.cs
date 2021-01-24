    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    namespace Foo
    {
        public class RestService : IDisposable
        {
            private bool _disposed = false;
            private HttpClient _client;
            public RestService()
            {
                _client = new HttpClient();
                _client.Timeout = TimeSpan.FromSeconds(60);
            }
            public async Task<T> GetRequest<T>(string queryURL)
            {
                T result = default(T);
                using (HttpResponseMessage response = _client.GetAsync(queryURL).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        using (HttpContent content = response.Content)
                        {
                            result = await content.ReadAsAsync<T>();
                        }
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }
                }
                return result;
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        if (_client != null)
                        {
                            _client.Dispose();
                        }
                    }
                    _disposed = true;
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
