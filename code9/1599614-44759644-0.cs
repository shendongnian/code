    public static string PostContent(this Uri url, string body, string contentType = null)
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            if (!string.IsNullOrEmpty(contentType)) request.ContentType = contentType;
            using (var requestStream = request.GetRequestStream())
            {
                if (!string.IsNullOrEmpty(body)) using (var writer = new StreamWriter(requestStream)) { writer.Write(body); }
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        public static string GetContent(this Uri url)
        {
            WebClient client = new WebClient();
            try
            {
                using (client)
                {
                    client.Encoding = Encoding.UTF8;
                    return client.DownloadString(url);
                }
            }
            catch (WebException)
            {
                return "";
            }
            finally
            {
                client.Dispose();
                client = null;
            }
        }
