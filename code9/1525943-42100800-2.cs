    //You must change the path to point to your .cer file location. 
    X509Certificate Cert = X509Certificate.CreateFromCertFile("C:\\mycert.cer");
    // Handle any certificate errors on the certificate from the server.
    ServicePointManager.CertificatePolicy = new CertPolicy();
    // You must change the URL to point to your Web server.
    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://YourServer");
    Request.ClientCertificates.Add(Cert);
    Request.UserAgent = "Client Cert Sample";
    Request.Method = "GET";
    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
