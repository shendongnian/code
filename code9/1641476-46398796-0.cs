 
           
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("https://archive.org/details/OTRR_In_The_Name_Of_The_Law_Singles");
    
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 ;
    
            using (WebClient webClient = new WebClient())
            {
                var stream = webClient.OpenRead(address);
                using (StreamReader sr =new StreamReader(stream))
                {
                    var page = sr.ReadToEnd();
                }
            }
        }
    
        /// <summary>
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
    }
