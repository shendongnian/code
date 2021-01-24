        static void Main(string[] args)
        {
          X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
          certStore.Open(OpenFlags.ReadOnly);
          X509Certificate2Collection certCollection = certStore.Certificates.Find(
                                     X509FindType.FindByThumbprint,
                                     // Replace below with your cert's thumbprint
                                     “E661583E8FABEF4C0BEF694CBC41C28FB81CD870”,
                                     false);
          // Get the first cert with the thumbprint
          if (certCollection.Count > 0)
          {
            X509Certificate2 cert = certCollection[0];
            // Use certificate
            Console.WriteLine(cert.FriendlyName);
          }
          certStore.Close();
        }
      
