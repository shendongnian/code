    public class CertificateHelper
    {
        protected internal static X509Certificate2 GetServiceCertificate(string subjectName)
        {
            using (var certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine))
            {
                certStore.Open(OpenFlags.ReadOnly);
                var certCollection = certStore.Certificates.Find(
                                           X509FindType.FindBySubjectDistinguishedName, subjectName, true);
                X509Certificate2 certificate = null;
                if (certCollection.Count > 0)
                {
                    certificate = certCollection[0];
                }
                return certificate;
            }
        }
    
        protected internal static string GetCertificateSubjectNameBasedOnEnvironment(string environment)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environment}.json", optional: false);
    
            var configuration = builder.Build();
            return configuration["ServerCertificateSubject"];
        }
    }
