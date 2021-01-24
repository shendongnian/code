    System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) =>
                {
                    if (cert != null) System.Diagnostics.Debug.WriteLine(cert);
                    return true;
                };
