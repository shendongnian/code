            public void StubInterenetExplorer11()
            {
                  StubBrowserCapabilities("Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");
            }
            public void StubBrowserCapabilities(string userAgentString)
            {
                var browser = new HttpBrowserCapabilities
                {
                    Capabilities = new Hashtable { { string.Empty, userAgentString } }
                };
                var factory = new BrowserCapabilitiesFactory();
                factory.ConfigureBrowserCapabilities(new NameValueCollection(), browser); 
                HttpRequest.Stub(a => a.Browser).Return(browser);
            }
