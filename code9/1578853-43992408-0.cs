                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;            //System.Net.ServicePointManager.
            try
            {
                var stub = new ServiceReference1.ServiceClient();
                stub.ClientCredentials.UserName.UserName = "user";
                stub.ClientCredentials.UserName.Password = "pass";
                //stub.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                
                stub.calculate("Test");
            }
            catch (Exception ee)
            {
            }
