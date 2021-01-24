    var handler = new HttpClientHandler();
    
    // Optional check to enable / disable based on config setting.
    if (ConfigurationManager.AppSettings["EnableSslCertificateCheck"] == null ||
    	Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSslCertificateCheck"]) == false)
    {
    	handler = new HttpClientHandler
    	{
    		ClientCertificateOptions = ClientCertificateOption.Manual,
    		ServerCertificateCustomValidationCallback =
    			(httpRequestMessage, cert, cetChain, policyErrors) => true
    	};
    }
    
    return new HttpClient(handler);
