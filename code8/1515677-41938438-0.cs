        ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        X509Certificate cer = new X509Certificate("F:\\csharp2.cer");  //adding your client certificate.
            httpWebRequest.ClientCertificates.Add(cer);
            httpWebRequest.BeginGetResponse(CallBack(), httpWebRequest);
        
        private void CallBack()
        {
            AsyncCallback ac = (result) =>
            {
                HttpWebRequest webRequest = (HttpWebRequest)result.AsyncState;
                using (HttpWebResponse response = (HttpWebResponse)webRequest.EndGetResponse(result))
                {
                    //response
                }
            };
        }
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return (sslPolicyErrors == SslPolicyErrors.None);
        }
