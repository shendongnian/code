    System.Net.WebException: An exception occurred during a WebClient request. ---> System.ArgumentException: The 'Range' header must be modified using the appropriate property or method.
    Parameter name: name
       at System.Net.WebHeaderCollection.ThrowOnRestrictedHeader(String headerName)
       at System.Net.WebHeaderCollection.Add(String name, String value)
       at System.Net.HttpWebRequest.set_Headers(WebHeaderCollection value)
       at System.Net.WebClient.CopyHeadersTo(WebRequest request)
       at System.Net.WebClient.GetWebRequest(Uri address)
       at System.Net.WebClient.DownloadFileAsync(Uri address, String fileName, Object userToken)
       --- End of inner exception stack trace ---
