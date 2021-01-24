    using CERTCLILib;
    using Microsoft.Extensions.Options;
    using OpenShare.Net.Library.Common;
    using OpenShare.Net.Library.Common.Types;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Asn1.Pkcs;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.X509;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Web.Security;
    using netCertificate = System.Security.Cryptography.X509Certificates;
    public Object GeneratePkcs10(string dnsName, string name, int phoneNumber)
            {
                string privateKey = null;
                const string TemplateOid = "1.3.6.1.4 etc etc"; // CA Template OID
                const int majorVersion = 100;
                const int minorVersion = 4;
                Certificate returnCertificate = new Certificate();
                using (new Impersonation(_foo, _faa, _pw, LogonType.LogonNewCredentials))
                {
                    try
                    {
                        // Structuring the ASN1 schema to accept a CA template
                        DerObjectIdentifier certificateTemplateExtensionOid = new DerObjectIdentifier("1.3.6.1.4.1.311.21.7");
                        DerSequence certificateTemplateExtension = new DerSequence(new DerObjectIdentifier(TemplateOid), new DerInteger(majorVersion), new DerInteger(minorVersion));
                        Dictionary<DerObjectIdentifier, X509Extension> extensionsDictionary = new Dictionary<DerObjectIdentifier, X509Extension>
                        {
                            [certificateTemplateExtensionOid] = new X509Extension(DerBoolean.False, new DerOctetString(certificateTemplateExtension))
                        };
                        // Creating keys
                        var genParam = new RsaKeyGenerationParameters(BigInteger.ValueOf(0x10001), new SecureRandom(), (int)RootLenght.RootLength2048, 128);
                        var rsaKeyPairGenerator = new RsaKeyPairGenerator();
                        rsaKeyPairGenerator.Init(genParam);
                        AsymmetricCipherKeyPair pair = rsaKeyPairGenerator.GenerateKeyPair();
                        
                        // Attatching attributes
                        var attrs = new Dictionary<DerObjectIdentifier, string> {{X509Name.CN, dnsName}};
                        var subject = new X509Name(attrs.Keys.ToList(), attrs);
                        // Creating the request
                        var pkcs10CertificationRequest = new Pkcs10CertificationRequest(PkcsObjectIdentifiers.Sha256WithRsaEncryption.Id, subject, pair.Public, new DerSet(new DerSequence(PkcsObjectIdentifiers.Pkcs9AtExtensionRequest, new DerSet(new X509Extensions(extensionsDictionary)))), pair.Private);
                        var csr = Convert.ToBase64String(pkcs10CertificationRequest.GetEncoded());
                        // Sending the request
                        string strCert = SendRequest(csr, "Insert path to CA");
                        if (strCert.Length > 0) // We have a valid certificate!
                        {
                            // Create Bouncy castle certificate
                            X509CertificateParser parser = new X509CertificateParser();
                            X509Certificate x509Cert = parser.ReadCertificate(Convert.FromBase64String(strCert));
                            // Create .NET certificate (this makes getting the certificate thumbprint a lot easier)
                            netCertificate.X509Certificate2 microsoftCertificate = new netCertificate.X509Certificate2();
                            microsoftCertificate.Import(x509Cert.GetEncoded());
                            var path = $"C:\\Cert\\{dnsName}.{DateTime.Now.Ticks}.pfx";
                            var password = CreatePfxFile(x509Cert, pair.Private, path);
                            //Start creating a return object
                            returnCertificate.cert = strCert;
                            returnCertificate.IsValid = x509Cert.IsValidNow;
                            returnCertificate.Path = path;
                            returnCertificate.SerialNumber = x509Cert.SerialNumber.ToString();
                            returnCertificate.Subject = x509Cert.SubjectDN.ToString();
                            returnCertificate.Thumbprint = microsoftCertificate.Thumbprint;
                            returnCertificate.ValidFrom = x509Cert.NotBefore;
                            returnCertificate.ValidTo = x509Cert.NotAfter;
                            returnCertificate.FriendlyName = microsoftCertificate.FriendlyName;
                            // Send password to user
                            SendPassword.SendPasswordSms(name, phoneNumber, password, "CertificatePassword");
                            return returnCertificate;
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        return ex;
                    }
                }
            }
