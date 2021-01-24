            protected static async Task AddBodyToRequest(byte[] data, WebRequest request)
        {
            Logger.Debug("AddBodyToRequest: {0}", request.ContentType);
            var uri = request.RequestUri.AbsoluteUri;
            try
            {
                using (Stream stream = await Task<Stream>.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, null))
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("[{0}] {1}. AddBodyToRequest [{2}]"
                    , ex.GetType().Name, ex.Message, uri));
            }
        }
