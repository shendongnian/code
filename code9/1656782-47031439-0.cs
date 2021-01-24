        public class MockMessageHandler: HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
            {
                // Capture request properties, return response
            }
        }
