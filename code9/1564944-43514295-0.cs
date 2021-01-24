    private static X509Certificate2 GetStoreCertificate(string thumbprint)
    {
      List<StoreLocation> locations = new List<StoreLocation>
      { 
        StoreLocation.CurrentUser, 
        StoreLocation.LocalMachine
      };
      foreach (var location in locations)
      {
        X509Store store = new X509Store("My", location);
        try
        {
          store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
          X509Certificate2Collection certificates = store.Certificates.Find(
            X509FindType.FindByThumbprint, thumbprint, false);
          if (certificates.Count == 1)
          {
            return certificates[0];
          }
        }
        finally
        {
          store.Close();
        }
      }
      throw new ArgumentException(string.Format(
        "A Certificate with Thumbprint '{0}' could not be located.",
        thumbprint));
    }
