    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    namespace Certificate
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                CreateSoap(doc);
                XmlElement issuer = (XmlElement)(doc.GetElementsByTagName("saml2:Issuer")[0]);
                XmlElement body = (XmlElement)(doc.GetElementsByTagName("soap:Body")[0]);
                using (WebClient client = new WebClient())
                {
                    byte[] xmlBytes = client.DownloadData(FILENAME);
                    body.InnerXml = Encoding.UTF8.GetString(xmlBytes);
                }
                string pfxpath = @"D:\Certificate\Private-cert.pfx";
                X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes(pfxpath), "123456789");
                SignXmlWithCertificate(issuer, cert);
                File.WriteAllText(@"D:\Certificate\digitallysigned.xml", doc.OuterXml);
            }
            public static void CreateSoap(XmlDocument doc)
            {
                DateTime date = DateTime.Now;
                string soap = string.Format(
                    "<?xml version=\"1.0\"?>" +
                               "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">" +
                                   "<soap:Header>" +
                                       "<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" soap:mustUnderstand=\"true\">" +
                                           "<saml2:Assertion xmlns:saml2=\"urn:oasis:names:tc:SAML:2.0:assertion\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" ID=\"_883e64a747a5449b83821913a2b189e6\" IssueInstant=\"{0}\" Version=\"2.0\">" +
                                               "<saml2:Issuer Format=\"urn:oasis:names:tc:SAML:1.1:nameid-format:X509SubjectName\">CN=SampleConnect,O=SAMPLE,L=Anywhere,C=US</saml2:Issuer>" +
                                           "</saml2:Assertion>" +
                                           "<ds:Signature xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\">" +
                                           "<ds:SignedInfo xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"" + 
                                              "xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\"" +
                                              "xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\"" + 
                                              "xmlns:xenc=\"http://www.w3.org/2001/04/xmlenc#\">" +
                                              "<ds:CanonicalizationMethod Algorithm=\"http://www.w3.org/2001/10/xml-exc-c14n#\">" +
                                                 "<c14n:InclusiveNamespaces xmlns:c14n=\"http://www.w3.org/2001/10/xml-exc-c14n#\" PrefixList=\"ds wsu xenc SOAP-ENV \"/>" +
                                              "</ds:CanonicalizationMethod>" +
                                              "<ds:SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/>" +
                                                 "<ds:Reference URI=\"#TheBody\">" +
                                                    "<ds:Transforms>" +
                                                       "<ds:Transform Algorithm=\"http://www.w3.org/2001/10/xml-exc-c14n#\">" +
                                                          "<c14n:InclusiveNamespaces xmlns:c14n=\"http://www.w3.org/2001/10/xml-exc-c14n#\" PrefixList=\"wsu SOAP-ENV \"/>" +
                                                       "</ds:Transform>" +
                                                    "</ds:Transforms>" +
                                                    "<ds:DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/>" + 
                                                    "<ds:DigestValue>QORZEA+gpafluShspHxhrjaFlXE=</ds:DigestValue>" +
                                                "</ds:Reference>" +
                                           "</ds:SignedInfo>" +
                                           "<ds:SignatureValue>drDH0XESiyN6YJm27mfK1ZMG4Q4IsZqQ9N9V6kEnw2lk7aM3if77XNFnyKS4deglbC3ga11kkaFJ" + 
                                              "p4jLOmYRqqycDPpqPm+UEu7mzfHRQGe7H0EnFqZpikNqZK5FF6fvYlv2JgTDPwrOSYXmhzwegUDT" +
                                              "lTVjOvuUgXYrFyaO3pw=</ds:SignatureValue>" +
                                           "<ds:KeyInfo>" +
                                              "<wsse:SecurityTokenReference>" +
                                                 "<wsse:Reference URI=\"#x509cert00\"" + 
                                                 "ValueType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509\"/>" + 
                                              "</wsse:SecurityTokenReference>" +
                                           "</ds:KeyInfo>" +
                                        "</ds:Signature>" +
                                        "</wsse:Security>" +
                                    "</soap:Header>" +
                                    "<soap:Body>" +
                                    "</soap:Body>" +
                                 "</soap:Envelope>",
                                 date.ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
                //date format
                //2015-03-09T21:12:02.279Z
                doc.LoadXml(soap);
            }
            public static void SignXmlWithCertificate(XmlElement doc, X509Certificate2 cert)
            {
                SignedXml signedXml = new SignedXml(doc);
                signedXml.SigningKey = cert.PrivateKey;
                Reference reference = new Reference();
                reference.Uri = "";
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                signedXml.AddReference(reference);
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(cert));
                signedXml.KeyInfo = keyInfo;
                signedXml.ComputeSignature();
                XmlElement xmlsig = signedXml.GetXml();
                doc.AppendChild(xmlsig);
            }
        }
    }
