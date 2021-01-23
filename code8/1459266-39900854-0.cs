    public static class Ssl
    {
        private static readonly string[] TrustedHosts = new[] {
          "YourServiceName", 
          "YourServiceName2"
        };
    
        public static void EnableTrustedHosts()
        {
            ServicePointManager.ServerCertificateValidationCallback =
            (sender, certificate, chain, errors) =>
            {
                if (errors == SslPolicyErrors.None)
                {
                    return true;
                }
    
                var request = sender as HttpWebRequest;
                if (request != null)
                {
                    return TrustedHosts.Contains(request.RequestUri.Host);
                }
    
                return false;
            };
        }
    }
