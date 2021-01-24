    public class CodeActivity1 : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
    
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
     
                ITracingService tracingService = context.GetExtension<ITracingService>();
                var postUrl = "https://jsonplaceholder.typicode.com/posts/1";
    
                var request = (HttpWebRequest)WebRequest.Create(postUrl);
                request.Method = "GET";
                request.ContentType = "application/xml";
                request.ContentLength = 0;
                request.ServicePoint.Expect100Continue = true;
    
                HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
    
    			var result = responseStream.ReadToEnd();
    			webresponse.Close();
    			.....
        }
    ...
    }
