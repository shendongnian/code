     private void InvokeNotification(string methodName, params object[] args)
     {
         try
         {
             string serverIp = ConfigurationManager.AppSettings["ServerIp"];
             var connection = new HubConnection(serverIp, useDefaultUrl: true);
             var myHub = connection.CreateHubProxy("myhub");
             //This will ignore all certeficates
             //System.Net.ServicePointManager.ServerCertificateValidationCallback =
             //    ((sender, certificate, chain, sslPolicyErrors) => true);
             System.Net.ServicePointManager.ServerCertificateValidationCallback += 
						new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
             connection.Start().Wait();
             myHub.Invoke(methodName, args);
         }
         catch (Exception ex)
         {
             //Some error handling
         }
      }
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, 
										X509Chain chain, SslPolicyErrors policyErrors)
    {
        bool result = false;
        if (cert.Subject.ToUpper().Contains("MY_CERT_ISSUER_NAME"))
        {
            result = true;
        }
        return result;
    }
