    public void Navigate(this IWebBrowser browser, string url, byte[] postDataBytes, string contentType)
        {
            IFrame frame = browser.GetMainFrame();
            IRequest request = frame.CreateRequest();
            request.Url = url;
            request.Method = "POST";
            request.InitializePostData();
            var element = request.PostData.CreatePostDataElement();
            element.Bytes = postDataBytes;
            request.PostData.AddElement(element);
            NameValueCollection headers = new NameValueCollection();
            headers.Add("Content-Type", contentType );
            request.Headers = headers;
            frame.LoadRequest(request);
        }
