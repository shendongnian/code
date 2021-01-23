    private X509Certificate2 GetStoreCertificate(string thumbprint)
        {
            List<StoreLocation> locations = new List<StoreLocation> { StoreLocation.CurrentUser, StoreLocation.LocalMachine };
            foreach (var location in locations)
            {
                Console.WriteLine("location: " + location.ToString());
                X509Store store = new X509Store("My", location);
                try
                {
                    Console.WriteLine("Try, store.Open...");
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                    Console.WriteLine("store.Opened..." + store.Certificates.Count.ToString());
                    foreach (X509Certificate2 cert in store.Certificates)
                    {
                        Console.WriteLine("X509Certificate2 Thumbprint : " + cert.Thumbprint);
                    }
                    foreach (X509Certificate cert in store.Certificates)
                    {
                        Console.WriteLine("X509Certificate Thumbprint : " + cert.Issuer);
                    }
                    X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                    Console.WriteLine("Finding certificate.." + certificates.Count.ToString());
                    if (certificates.Count == 1)
                    {
                        Console.WriteLine("Atleast one found!!!");
                        return certificates[0];
                    }
                }
                finally
                {
                    store.Close();
                }
            }
            throw new ArgumentException(string.Format("A Certificate with Thumbprint '{0}' could not be located.", thumbprint));
        }
