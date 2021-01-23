    private void buttonSelectCertificate_Click(object sender, EventArgs e)
    {
       CertStoreLocation = (StoreLocation)cboStoreLocation.SelectedItem;
       CertStoreName = (StoreName)cboStoreName.SelectedItem;
       X509Store store = new X509Store(CertStoreName, CertStoreLocation);
                store.Open(OpenFlags.ReadOnly);
       X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(store.Certificates, "Certificate Select", "Select a certificate from the following list to get information on that certificate",  System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection);
    
    
      foreach (X509Certificate2 cert in scollection)
                {
    
                    var rsa = cert.PrivateKey as RSACryptoServiceProvider;
                    if (rsa == null) continue; // not smart card cert again
    
                    if (!string.IsNullOrEmpty(rsa.CspKeyContainerInfo.KeyContainerName))
                    {
                        // This is how we can get it! :)  
                        var keyContainerName = rsa.CspKeyContainerInfo.KeyContainerName;
                    }
                }
    }
