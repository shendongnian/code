    NetworkCredential credentials = new NetworkCredential{
    Username=//fill your username,
    Password=//fill your password but be carefull, is it hashed or not?
    };
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Credentials = credentials;
    
       try
       {
           WebResponse response = request.GetResponse();
           using(Stream responseStream = response.GetResponseStream())
           {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
           }
       }
       catch(WebException Ex)
       {
            WebResponse errorResponse = Ex.Response;
            using(Stream responseStream = errorResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                string errorText = reader.ReadToEnd();
            }
            throw;
        }
