    HttpWebRequest request = (HttpWebRequest) WebRequest.Create("")
    request.Method = "POST";
    request.ContentType = "text/xml;charset=\"utf-8\"";
    request.ContentLength = RequestingXMLData.Length;
    using (Stream webStream = request.GetRequestStream())
    using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.UTF8))
    {
       requestWriter.Write(RequestingXMLData);
       try
       {
           WebResponse webResponse = request.GetResponse();
           using (Stream webStream = webResponse.GetResponseStream())
           {
                if (webStream != null)
                {
                     using (StreamReader responseReader = new StreamReader(webStream))
                     {
                         response = responseReader.ReadToEnd();
                     }
                 }
           }
       }
       catch (WebException e)
       {
            var resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
       }
    }
