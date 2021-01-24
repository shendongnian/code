            string url = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
          
            var webResponse = request.GetResponse();
            using (var s = webResponse.GetResponseStream())
            {
                using (TextReader textReader = new StreamReader(s, true))
                {
                   string jsonString = textReader.ReadToEnd();
                }
            }
