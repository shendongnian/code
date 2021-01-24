    X509Store st0re = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            st0re.Open(OpenFlags.ReadOnly);
            count = st0re.Certificates.Count;       //Count the certificates in the store
            X509Certificate2Collection certs = st0re.Certificates.Find(
                X509FindType.FindBySubjectDistinguishedName,
                "C=US, S=WA, L=Redmond, O=Microsoft Corporation, OU=Web Services",
                true);
            st0re.Close();
            Output = certs[0].ToString();       // = count.ToString()
