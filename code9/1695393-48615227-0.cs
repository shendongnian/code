    string URL = ""; //your url
    if (URL.Contains("https"))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object s, X509Certificate ce, X509Chain ch, SslPolicyErrors tls) => true));
                }
    CookieContainer cookieJar = new CookieContainer();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);   
    string petition = ""; //leave empty for get requests  
    string result = ""; //if the server answers it will do so here
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";
    var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
               
                    streamWriter.Write(Petition);
                    streamWriter.Flush();
                    streamWriter.Close();
               
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());
                result = streamReader.ReadToEnd();
