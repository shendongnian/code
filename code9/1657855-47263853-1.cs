    using (var client = new NoKeepAlivesWebClient())
    {
        bResponse = client.UploadData(serverName, "POST", bb);
    }
    
    /// Certificate validation callback.
    /// </summary>
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
        // If the certificate is a valid, signed certificate, return true.
        if (error == System.Net.Security.SslPolicyErrors.None)
        {
    	return true;
        }
    
        Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
    	cert.Subject,
    	error.ToString());
    
        return false;
    }
    
    public class NoKeepAlivesWebClient : WebClient
    {
    	protected override WebRequest GetWebRequest(Uri address)
    	{
    	    var request = base.GetWebRequest(address);
    	    if (request is HttpWebRequest)
    	    {
    		((HttpWebRequest)request).KeepAlive = false;
    		((HttpWebRequest)request).Timeout = 60000;
    	    }
    
    	    return request;
    	}
    }
