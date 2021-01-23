    public class HttpRequestResponse
    {
        private WebRequest request;
        public T Fetchresult<T>()
        {
            request = WebRequest.Create("URL");
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = js.Deserialize<T>(responseFromServer);
            return obj;
    
        }
    }
