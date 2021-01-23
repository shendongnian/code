    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    namespace MyNamespace {
        class MyClass {
            public static String GetSha2Thumbprint(X509Certificate2 cert) {
                Byte[] hashBytes;
                using (var hasher = new SHA256Managed()) {
                    hashBytes = hasher.ComputeHash(cert.RawData);
                }
                return BitConverter.ToString(hashBytes).Replace("-", ":");
            }
        }
    }
