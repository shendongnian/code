        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Input.WebRequest);
            httpWebRequest.ContentType = Input.ContentType;
            httpWebRequest.Method = "POST";
            PingReply Objping = new Ping().Send(IPAddress.Parse(Input.Address), 1000);
            string result;
            if (Objping.Status == IPStatus.Success)
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(Input.Json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
            return null;
           
     
        }
