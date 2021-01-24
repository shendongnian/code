        static void Main(string[] args)
        {
            Console.WriteLine("Plus API - Service Account");
            Console.WriteLine("==========================");
            String serviceAccountEmail = "xxxx@xxxx-xxxx.xx.gserviceaccount.com";
            var certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory +
                 "xxxxxxxxxx.p12", "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { GmailService.Scope.MailGoogleCom },
                   User = "xxxx@xxxxxxx.net"//ur Gsuit Id
               }.FromCertificate(certificate));
            // Create the service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "xxxxx",
            });
          
