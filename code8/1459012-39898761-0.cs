    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    namespace Demo
    {
        public static class DemoClass
        {
            public static bool ECDsaSha256Verify(string pemCert, string data, byte[] signature)
            {
                using (var cert = new X509Certificate2(Encoding.ASCII.GetBytes(pemCert)))
                using (ECDsa ecdsa = cert.GetECDsaPublicKey())
                {
                    if (ecdsa == null)
                    {
                        throw new ArgumentException("Certificate does not have an ECDSA key.");
                    }
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    return ecdsa.VerifyData(dataBytes, signature, HashAlgorithmName.SHA256);
                }
            }
        }
    }
