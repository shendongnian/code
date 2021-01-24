    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => {
    	if (errors == SslPolicyErrors.None) return true;
    	X509Certificate2 serverCert = new X509Certificate2(certificate);
    	X509Certificate2 caCert = new X509Certificate2(@"./ca.cert");
    	chain.ChainPolicy.ExtraStore.Add(caCert);
    	chain.Build(serverCert);
    	foreach (var chainStatus in chain.ChainStatus) {
    		if (chainStatus.Status == X509ChainStatusFlags.UntrustedRoot) continue;
    		if (chainStatus.Status != X509ChainStatusFlags.NoError) return false;
    	}
    	return true;
    };
    HttpWebRequest request = WebRequest.CreateHttp("https://master:6443/api/v1");
    request.Headers[HttpRequestHeader.Authorization] = "Bearer " + "SOME_TOKEN";
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    var content = new StreamReader(response.GetResponseStream()).ReadToEnd();
    Console.WriteLine(content);
