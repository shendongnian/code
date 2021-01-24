    public static class ExchangeServerService
    {
        // The following is a basic redirection validation callback method. It 
        // inspects the redirection URL and only allows the Service object to 
        // follow the redirection link if the URL is using HTTPS. 
        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;
            Uri redirectionUri = new Uri(redirectionUrl);
            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
        public static ExchangeService ConnectToService()
        {
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
                service.Credentials = new NetworkCredential(@"email", "password");
                service.AutodiscoverUrl(@"email", RedirectionUrlValidationCallback);
                
                return service;
            }
            catch (Exception ex)
            {
                // log exception maybe
                return null;
            }
        }
    }
