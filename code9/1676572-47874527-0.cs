            public void StubBrowserCapabilities()
            {
                var userAgent = "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
                var browser = new HttpBrowserCapabilities
                {
                    Capabilities = new Hashtable { { string.Empty, userAgent } }
                };
                var factory = new BrowserCapabilitiesFactory();
                factory.ConfigureBrowserCapabilities(new NameValueCollection(), browser); 
                HttpRequest.Stub(a => a.Browser).Return(browser);
            }
