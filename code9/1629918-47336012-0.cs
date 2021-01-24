        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HandleBounce() //This method is called from Amazon Simple Notification Service when we receive a bounce.
        {
            string notification = "";
            using (var stream = new MemoryStream())
            {
                var request = HttpContext.Current.Request;
                request.InputStream.Seek(0, SeekOrigin.Begin);
                request.InputStream.CopyTo(stream);
                notification = Encoding.UTF8.GetString(stream.ToArray());
            }
        }
