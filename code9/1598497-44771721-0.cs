    public class DawgWebViewClient: WebViewClient
    {
        private class DawgWebResourceResponse : WebResourceResponse
        {
            IWebResourceRequest baseRequest;
            public DawgWebResourceResponse(IWebResourceRequest request) : base(null, null, null)
            {
                this.baseRequest = request;
                this.LoadRequestAsync();
            }
            ManualResetEvent responseDataWaiter = new ManualResetEvent(false);
            ManualResetEvent metaDataWaiter = new ManualResetEvent(false);
            private void LoadRequestAsync()
            {
                Task.Run(async () =>
                {
                    HttpClient client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
                    foreach(var header in this.baseRequest.RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    HttpResponseMessage response;
                    switch(this.baseRequest.Method)
                    {
                        case "GET":
                            response = await client.GetAsync(this.baseRequest.Url.ToString());
                            break;
                        default:
                            response = null;
                            Debugger.Break();
                            break;
                    }
                    string
                        mediaType = response.Content.Headers.ContentType?.MediaType ?? "*/*",
                        charSet = response.Content.Headers.ContentType?.CharSet ?? "UTF-8";
                    this.MimeType = mediaType;
                    this._statusCode = (int)response.StatusCode;
                    this.ResponseHeaders = response.Headers.ToDictionary(y => y.Key, y => y.Value.FirstOrDefault());
                    metaDataWaiter.Set();
                    this.Data = await response.Content.ReadAsStreamAsync();
                    responseDataWaiter.Set();
                });
            }
            public override Stream Data
            {
                get {
                    this.responseDataWaiter.WaitOne();
                    return base.Data;
                }
                set
                {
                    base.Data = value;
                }
            }
            public override IDictionary<string, string> ResponseHeaders
            {
                get
                {
                    this.metaDataWaiter.WaitOne();
                    return base.ResponseHeaders;
                }
                set
                {
                    base.ResponseHeaders = value;
                }
            }
            private int _statusCode = 0;
            public override int StatusCode
            {
                get
                {
                    this.metaDataWaiter.WaitOne();
                    return this._statusCode;
                }
            }
            public override string Encoding
            {
                get
                {
                    this.metaDataWaiter.WaitOne();
                    return base.Encoding;
                }
                set
                {
                    base.Encoding = value;
                }
            }
            public override string ReasonPhrase
            {
                get
                {
                    this.metaDataWaiter.WaitOne();
                    return base.ReasonPhrase;
                }
            }
            public override string MimeType
            {
                get
                {
                    this.metaDataWaiter.WaitOne();
                    return base.MimeType;
                }
                set
                {
                    base.MimeType = value;
                }
            }
        }
        public override WebResourceResponse ShouldInterceptRequest(Android.Webkit.WebView view, IWebResourceRequest request)
        {
            if(request.RequestHeaders["Accept"]?.Contains("text/html") == true) return new DawgWebResourceResponse(request);
            return null;
        }
    }
