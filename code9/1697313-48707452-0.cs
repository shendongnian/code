            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);
            HashSet<string> certificateNames = new HashSet<string>();
            foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 mCert in store.Certificates)
            {
                // is this a UCC certificate?
                System.Security.Cryptography.X509Certificates.X509Extension uccSan = mCert.Extensions["2.5.29.17"];
                if (uccSan != null)
                {
                    foreach (string nvp in uccSan.Format(true).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string[] parts = nvp.Split('=');
                        string name = parts[0];
                        string value = (parts.Length > 0) ? parts[1] : null;
                        if (String.Equals(name, "DNS Name", StringComparison.InvariantCultureIgnoreCase))
                        {
                            certificateNames.Add(value.ToLowerInvariant());
                        }
                    }
                }
                else // just a regular certificate--add the single name
                {
                    string certificateHost = mCert.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, false);
                    certificateNames.Add(certificateHost.ToLowerInvariant());
                }
            }
            return certificateNames;
