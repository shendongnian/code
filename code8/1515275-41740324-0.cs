    private class MockHttpContext : HttpContextBase {
        private readonly MockRequest request;
        public MockHttpContext(HttpCookieCollection cookies) {
            this.request = new MockRequest(cookies);
        }
        public override HttpRequestBase Request {
            get {
                return request;
            }
        }
        public class MockRequest : HttpRequestBase {
            private readonly HttpCookieCollection cookies;
            public MockRequest(HttpCookieCollection cookies) {
                this.cookies = cookies;
            }
            public override HttpCookieCollection Cookies {
                get {
                    return cookies;
                }
            }
        }
    }
