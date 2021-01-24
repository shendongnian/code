    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(FILENAME);
                string computerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
                string userName = Environment.GetEnvironmentVariable("USERNAME");
                X509Certificate2 cert = GetCertificateFromStore("CN=" + computerName + "\\" + userName);
                SignXmlDocumentWithCertificate(doc, cert);
                RSACryptoServiceProvider publicKey = (RSACryptoServiceProvider)cert.PublicKey.Key;
                byte[] unencryptedData = Encoding.UTF8.GetBytes(doc.OuterXml); 
                Stream stream = EncryptFile(unencryptedData,publicKey);
                Console.ReadLine();
            }
            public static void SignXmlDocumentWithCertificate(XmlDocument doc, X509Certificate2 cert)
            {
                SignedXml signedxml = new SignedXml(doc);
                signedxml.SigningKey = cert.PrivateKey;
                Reference reference = new Reference();
                reference.Uri = "";
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                signedxml.AddReference(reference);
                KeyInfo keyinfo = new KeyInfo();
                keyinfo.AddClause(new KeyInfoX509Data(cert));
                signedxml.KeyInfo = keyinfo;
                signedxml.ComputeSignature();
                XmlElement xmlsig = signedxml.GetXml();
                doc.DocumentElement.AppendChild(doc.ImportNode(xmlsig, true));
                //Console.WriteLine(doc.ImportNode(xmlsig,true));
            }
     
            private static X509Certificate2 GetCertificateFromStore(string certName)
            {
                // Get the certificate store for the current user.
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    // Place all certificates in an X509Certificate2Collection object.
                    X509Certificate2Collection certCollection = store.Certificates;
                    // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                    // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                    X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                    X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                    if (signingCert.Count == 0)
                        return null;
                    // Return the first certificate in the collection, has the right name and is current.
                    return signingCert[0];
                }
                finally
                {
                    store.Close();
                }
            }
            // Encrypt a file using a public key.
            private static MemoryStream  EncryptFile(byte[] unencryptedData, RSACryptoServiceProvider rsaPublicKey)
            {
                MemoryStream stream = null;
                using (AesManaged aesManaged = new AesManaged())
                {
                    // Create instance of AesManaged for
                    // symetric encryption of the data.
                    aesManaged.KeySize = 256;
                    aesManaged.BlockSize = 128;
                    aesManaged.Mode = CipherMode.CBC;
                    using (ICryptoTransform transform = aesManaged.CreateEncryptor())
                    {
                        RSAPKCS1KeyExchangeFormatter keyFormatter = new RSAPKCS1KeyExchangeFormatter(rsaPublicKey);
                        byte[] keyEncrypted = keyFormatter.CreateKeyExchange(aesManaged.Key, aesManaged.GetType());
                        // Create byte arrays to contain
                        // the length values of the key and IV.
                        byte[] LenK = new byte[4];
                        byte[] LenIV = new byte[4];
                        int lKey = keyEncrypted.Length;
                        LenK = BitConverter.GetBytes(lKey);
                        int lIV = aesManaged.IV.Length;
                        LenIV = BitConverter.GetBytes(lIV);
                        // Write the following to the FileStream
                        // for the encrypted file (outFs):
                        // - length of the key
                        // - length of the IV
                        // - ecrypted key
                        // - the IV
                        // - the encrypted cipher content
                        stream = new MemoryStream();
                        try
                        {
                            stream.Write(LenK, 0, 4);
                            stream.Write(LenIV, 0, 4);
                            stream.Write(keyEncrypted, 0, lKey);
                            stream.Write(aesManaged.IV, 0, lIV);
                            // Now write the cipher text using
                            // a CryptoStream for encrypting.
                            CryptoStream outStreamEncrypted = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                            try
                            {
                                // By encrypting a chunk at
                                // a time, you can save memory
                                // and accommodate large files.
                                int count = 0;
                                int offset = 0;
                                // blockSizeBytes can be any arbitrary size.
                                int blockSizeBytes = aesManaged.BlockSize / 8;
                                do
                                {
                                    if (offset + blockSizeBytes <= unencryptedData.Length)
                                    {
                                        count = blockSizeBytes;
                                    }
                                    else
                                    {
                                        count = unencryptedData.Length - offset;
                                    }
                                    outStreamEncrypted.Write(unencryptedData, offset, count);
                                    offset += count;
                                }
                                while (offset < unencryptedData.Length);
                                outStreamEncrypted.FlushFinalBlock();
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Error : {0}", ex.Message);
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error : {0}", ex.Message);
                        }
                        stream.Position = 0;
                    }
                }
                return stream;
            }
        }
    }
