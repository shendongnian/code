    using (response = (HttpWebResponse)request.GetResponse())
    {
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException("error code " +      response.StatusCode.ToString());
        }
     }
    
    //process the response stream ..(json , html , etc..  )
    Encoding enc = System.Text.Encoding.GetEncoding(1252);
    StreamReader loResponseStream = new
    StreamReader(response.GetResponseStream(), enc);
    
