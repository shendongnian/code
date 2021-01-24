        public static void PostHTML(string uri)
        {
            WebClient request = new WebClient();
            request.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string postString = "userName=user&password=password&html=" + GetWebTemplate();
            var response = request.UploadString(uri,"POST", postString);
            Debug.WriteLine(response);
            request.Dispose();
        }
