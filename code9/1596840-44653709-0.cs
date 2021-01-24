    public static bool GetResponseForJson( string url, out object jsonObject )
    {
      bool result;
      try {
        HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( url );
        webRequest.Method = "POST";
        HttpWebResponse httpWebResponse = ( HttpWebResponse )webRequest.GetResponse();
        StreamReader sr = new StreamReader( httpWebResponse.GetResponseStream() );
        jsonObject = new JavaScriptSerializer().DeserializeObject( sr.ReadToEnd() );
        result = true;
      }
      catch {
        
        jsonObject = null;
        result = false;
      }
      return result;
    }
