    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
    static void Main(string[] args)
    {
        string file_ = "https://www.nseindia.com/content/circulars/CMPT34469.pdf";
        string path_ = @"E:\RSR\Office\EEP\FileDownloader\output\Hello_World.pdf";
        WebClient wc_ = new WebClient();
        wc_.Headers.Add(HttpRequestHeader.UserAgent, "Other");
        wc_.Headers.Add(HttpRequestHeader.Accept, "application/pdf");
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        wc_.DownloadFile(file_, path_);
    }
