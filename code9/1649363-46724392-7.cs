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
                XmlElement assertion = (XmlElement)(doc.GetElementsByTagName("saml2:Assertion")[0]);
                XmlElement security = (XmlElement)(doc.GetElementsByTagName("wsse:Security")[0]);  //added 10-20-17
                XmlElement body = (XmlElement)(doc.GetElementsByTagName("soap:Body")[0]);
                using (WebClient client = new WebClient())
                {
                    byte[] xmlBytes = client.DownloadData(FILENAME);
                    body.InnerXml = Encoding.UTF8.GetString(xmlBytes);
                }
                string pfxpath = @"D:\Certificate\Private-cert.pfx";
                X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes(pfxpath), "123456789");
                SignXmlWithCertificate(assertion, cert);
                SignXmlWithCertificate(security, cert);   //added 10-20-17
                XmlElement subject = doc.CreateElement("Subject", "saml2");
                assertion.AppendChild(subject);
                CreateSubject(subject);
                File.WriteAllText(@"D:\Certificate\digitallysigned.xml", doc.OuterXml);
            }
            public static void CreateSoap(XmlDocument doc)
            {
                DateTime date = DateTime.Now;
                string soap = string.Format(
                    "<?xml version=\"1.0\"?>" +
                    "<soap:Envelope" +
                    " xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\"" +
                    " xmlns:wsse11=\"http://docs.oasisopen.org/wss/oasis-wss-wssecurity-secext-1.1.xsd\"" +
                    " xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"" +
                    " xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wsswssecurity-utility-1.0.xsd\"" +
                    " xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"" +
                    " xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\"" +
                    " xmlns:saml=\"urn:oasis:names:tc:SAML:1.0:assertion\"" +
                    " xmlns:exc14n=\"http://www.w3.org/2001/10/xml-exc-c14n#\">" +
                               "<soap:Header>" +
                                      "<To mustUnderstand=\"true\"" +
                                         " xmlns=\"http://www.w3.org/2005/08/addressing\">https://localhost:443/Gateway/PatientDiscovery/1_0/NwHINService/NwHINPatientDiscovery" +
                                      "</To>" +
                                      "<Action mustUnderstand=\"true\"" +
                                         " xmlns=\"http://www.w3.org/2005/08/addressing\">urn:hl7-org:v3:PRPA_IN201305UV02:CrossGatewayPatientDiscovery" +
                                      "</Action>" +
                                      "<ReplyTo mustUnderstand=\"true\"" +
                                         " xmlns=\"http://www.w3.org/2005/08/addressing\">" +
                                         "<Address>http://www.w3.org/2005/08/addressing/anonymous</Address>" +
                                      "</ReplyTo>" +
                                      "<MessageID mustUnderstand=\"true\"" +
                                         " xmlns=\"http://www.w3.org/2005/08/addressing\">461433e3-4591-453b-9eb6-791c7f5ff882" +
                                      "</MessageID>" +
                                      "<wsse:Security soap:mustUnderstand=\"true\">" +
                                         "<wsu:Timestamp wsu:Id=\"_1\"" +
                                            " xmlns:ns17=\"http://docs.oasis-open.org/ws-sx/wssecureconversation/200512\"" +
                                            " xmlns:ns16=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                                            "<wsu:Created>2012-06-08T18:31:44Z</wsu:Created>" +
                                            "<wsu:Expires>2012-06-08T18:36:44Z</wsu:Expires>" +
                                         "</wsu:Timestamp>" +
                                         "<saml2:Assertion ID=\"_883e64a747a5449b83821913a2b189e6\" IssueInstant=\"{0}\" Version=\"2.0\"" +
                                            " xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\"" +
                                            " xmlns:exc14n=\"http://www.w3.org/2001/10/xml-excc14n#\"" +
                                            " xmlns:saml2=\"urn:oasis:names:tc:SAML:2.0:assertion\"" +
                                            " xmlns:xenc=\"http://www.w3.org/2001/04/xmlenc#\"" +
                                            " xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">" +
                                            "<saml2:Issuer Format=\"urn:oasis:names:tc:SAML:1.1:nameid-format:X509SubjectName\">CN=SAML User,OU=SU,O=SAML User,L=Los Angeles,ST=CA,C=US" +
                                            "</saml2:Issuer>" +
                                         "</saml2:Assertion>" +
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
            public static void SignXmlWithCertificate(XmlElement assertion, X509Certificate2 cert)
            {
                SignedXml signedXml = new SignedXml(assertion);
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
                assertion.AppendChild(xmlsig);
            }
            public static void CreateSubject(XmlElement xSubject)
            {
                string subject = "<saml2:NameID Format=\"urn:oasis:names:tc:SAML:1.1:nameidformat:X509SubjectName\">UID=WilmaAnderson</saml2:NameID>" +
                                  "<saml2:SubjectConfirmation Method=\"urn:oasis:names:tc:SAML:2.0:cm:holder-ofkey\">" +
                                    "<saml2:SubjectConfirmationData>" +
                                      "<ds:KeyInfo>" +
                                        "<ds:KeyValue>" +
                                          "<ds:RSAKeyValue>" +
                                            "<ds:Modulus>" +
                                              "maFp5lsEHjhrQQCL0e8cbxMoDpGk1r6Uion/LA2iuD3T+sspJh8TNToQrurpFFVY/u6IzHKIk64s9894pxbwYNwv/LzRVz" +
                                              "M5pOXmCT73KGAg3Cry+QOO5KrN8hR/OXyH90/LIS77FZY+bepqD6qx4URa2/GLll08fu8xh1wPFDMCFAmb2Xz/5gK0fimUXJAWi1+PlNKML" +
                                              "nDGxHgvz5ZwiN1/QwXcQEc1mcJCimLoiCSrk7nvmqkxX4ZZ1dYzQJWdlB8Om4r9Uu96q5cZFTYwSdivLpPFKSzn/2MI9NryZC0VaIBuHRhg" +
                                              "AmspAzM90BjLO5vtiwrrfx/E3uYcMjcSEQ==" +
                                            "</ds:Modulus>" +
                                            "<ds:Exponent>AQAB</ds:Exponent>" +
                                          "</ds:RSAKeyValue>" +
                                        "</ds:KeyValue>" +
                                      "</ds:KeyInfo>" +
                                    "</saml2:SubjectConfirmationData>" +
                                  "</saml2:SubjectConfirmation>";
                xSubject.InnerXml = subject;
            }
        }
    }
