    class MyWebClient:WebClient
    {
       protected override WebRequest GetWebRequest(Uri uri) 
       {   
           var wr = base.GetWebRequest(uri) as HttpWebRequest;
    	   wr.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
           return wr;
       }
    }
	
