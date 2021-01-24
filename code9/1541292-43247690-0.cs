        X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.MaxAllowed);
            
            // find cert by thumbprint
            var foundCerts = store.Certificates.Find(X509FindType.Thumbprint, "12345", true);
            if (foundCerts.Count == 0)
                return;
            var certForSigning = foundCerts[0];
            store.Close();
            // prepare password
            var pass = new SecureString();
            var passwordstring = "password";
            var chararr = passwordstring.ToCharArray();
            foreach (var i in chararr)
                pass.AppendChar(i);
            // take private key
            var privateKey = certForSigning.PrivateKey as RSACryptoServiceProvider;
            // make new CSP parameters based on parameters from current private key but throw in password
            CspParameters cspParameters = new CspParameters(1,
                 privateKey.CspKeyContainerInfo.ProviderName,
                 privateKey.CspKeyContainerInfo.KeyContainerName,
                 new System.Security.AccessControl.CryptoKeySecurity(),
                 pass);
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParameters);
            XmlDocument xmlDoc = new XmlDocument();
            // Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(path);
            // Sign the XML document. 
            SignXml(xmlDoc, rsaCryptoServiceProvider);
