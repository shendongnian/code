    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography;
    namespace TE
    {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // these variables should be changed to math your installation
                // find CSP's in this windows registry key:  HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography\Defaults\Provider
                string TokenCSPName = "Datakey RSA CSP";
                string TokenCertificateName = "ACME Inc";
                string NonTokenCertificateName = "SelfSigned";
                string certLocation = "Token"; // change to something else to use self signed "Token" for token
                // the certificate on the token should be installed into the local users certificate store
                // tokens will not store or export the private key, only the public key
                // find the certificate we want to use - there's no recovery if the certificate is not found
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.OpenExistingOnly);
                X509Certificate2Collection certificates = store.Certificates;
                X509Certificate2 certificate = new X509Certificate2();
                X509Certificate2 useCertificate = new X509Certificate2();
                if (certLocation == "Token")
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        certificate = certificates[i];
                        string subj = certificate.Subject;
                        List<X509KeyUsageExtension> extensions = certificate.Extensions.OfType<X509KeyUsageExtension>().ToList();
                        if (certificate.GetNameInfo(X509NameType.SimpleName, false).ToString() == TokenCertificateName)
                        {
                            for (int j = 0; j < extensions.Count; j++)
                            {
                                if ((extensions[j].KeyUsages & X509KeyUsageFlags.DigitalSignature) == X509KeyUsageFlags.DigitalSignature)
                                {
                                    useCertificate = certificate;
                                    j = extensions.Count + 1;
                                }
                            }
                        }
                    }
                } else
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        certificate = certificates[i];
                        string subj = certificate.Subject;
                        List<X509KeyUsageExtension> extensions = certificate.Extensions.OfType<X509KeyUsageExtension>().ToList();
                        if (certificate.GetNameInfo(X509NameType.SimpleName, false).ToString() == NonTokenCertificateName)
                            useCertificate = certificate;
                    }
                }
                CspParameters csp = new CspParameters(1, TokenCSPName);
                csp.Flags = CspProviderFlags.UseDefaultKeyContainer;
                csp.KeyNumber = (int)KeyNumber.Exchange;
                RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider(csp);
                string SignatureString = "Data that is to be signed";
                byte[] plainTextBytes = Encoding.ASCII.GetBytes(SignatureString);
                bool Verified = false;
                using (SHA1CryptoServiceProvider shaM = new SHA1CryptoServiceProvider())
                {
                    // hash the data to be signed - you can use signData and avoid the hashing if you like
                    byte[] hash = shaM.ComputeHash(plainTextBytes);
                    // sign the hash
                    byte[] digitalSignature = rsa1.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
                    // check your signature size here - if not 256 bytes then you may not be using the proper
                    // crypto provider
                    // Verify the signature with the hash
                    RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)useCertificate.PublicKey.Key;
                    Verified = rsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), digitalSignature);
                    if (Verified)
                    {
                        Console.WriteLine("Signature Verified");
                    }
                    else
                    {
                        Console.WriteLine("Signature Failed Verification");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
      }
    }
