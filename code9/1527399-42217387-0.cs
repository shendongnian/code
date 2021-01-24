    var b = new CustomBinding();
    
                var sec = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
                sec.EndpointSupportingTokenParameters.Signed.Add(new UserNameSecurityTokenParameters());
                sec.MessageSecurityVersion =
                    MessageSecurityVersion.
                        WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                sec.IncludeTimestamp = false;
                sec.MessageProtectionOrder = System.ServiceModel.Security.MessageProtectionOrder.EncryptBeforeSign;
    
                b.Elements.Add(sec);
                b.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
                b.Elements.Add(new HttpsTransportBindingElement());
    
                
                var c =
                    new ServiceReference1.SimpleServiceSoapClient(b, new EndpointAddress(new Uri("https://www.bankhapoalim.co.il/"), new DnsEndpointIdentity("WSE2QuickStartServer"), new AddressHeaderCollection()));
    
                c.ClientCredentials.UserName.UserName = "yaron";
                c.ClientCredentials.UserName.Password = "1234";
    
                c.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                    System.ServiceModel.Security.X509CertificateValidationMode.None;
                c.ClientCredentials.ServiceCertificate.DefaultCertificate = new X509Certificate2(@"C:\Program Files\Microsoft WSE\v2.0\Samples\Sample Test Certificates\Server Public.cer");
    
                c.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(@"C:\Program Files\Microsoft WSE\v2.0\Samples\Sample Test Certificates\Client Private.pfx", "wse2qs");
    
                c.Endpoint.Contract.ProtectionLevel = System.Net.Security.ProtectionLevel.Sign;
