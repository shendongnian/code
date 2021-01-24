    var handler = new WebRequestHandler();
	var certFile = Path.Combine(@"d:\temp\", "cert.pfx");
	handler.ClientCertificates.Add(new X509Certificate2(certFile, "password"));
	using (var client = new HttpClient(handler))
	{
        ....
    }
