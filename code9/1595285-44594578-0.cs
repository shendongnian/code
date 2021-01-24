    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.Security;
    using System.IO;
    using System.Security.Cryptography.X509Certificates
    var pkcs12Store = new Pkcs12Store();
    var certEntry = new X509CertificateEntry(bcCert);
    pkcs12Store.SetCertificateEntry(alias, certEntry);
    pkcs12Store.SetKeyEntry(alias, new AsymmetricKeyEntry(certKey.Private), new[] { certEntry });    
    X509Certificate2 keyedCert;
    using (MemoryStream pfxStream = new MemoryStream())
    {
    	pkcs12Store.Save(pfxStream, null, new SecureRandom());
    	pfxStream.Seek(0, SeekOrigin.Begin);
    	keyedCert = new X509Certificate2(pfxStream.ToArray());
    }
