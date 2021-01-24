    class Rest
    {
        //This takes the API Key and JSON array of data and posts it to the Message URL to send the SMS's
        public static string Post(string Token, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://platform.clickatell.com/messages");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", Token);
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
       }
    }
