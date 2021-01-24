    using System;
    using System.IdentityModel.Tokens;
    using System.ServiceModel;
    using System.ServiceModel.Security;
    using Microsoft.IdentityModel.Protocols.WSTrust;
    using WSTrustChannel = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel;
    using WSTrustChannelFactory = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory;
    
    namespace SOS.Tools.AdfsConnectionChecker
    {
    
        /// <summary> Parameters to get token from partner's ADFS 
        /// using his domain user credentials </summary>
        public class AdfsIdentityProviderTokenRequest
        {
            /// <summary>Domain user from identity provider domain. 
            /// E.g. Name.FamalyName@ipDomainName.local or ipDomain2kName\Name.FamalyName </summary>
            public string IpDomainUserName { get; set; }
            /// <summary>Domain user password</summary>
            public string IpDomainUserPassword { get; set; }
            /// <summary> Identyty provider  token issuer server, i.e your partner adfs server. 
            /// E.g. adfs.partnerdomain.com</summary>
            public string IpTokenIssuerServer { get; set; }
            /// <summary>Resources token issuer server, i.e. your company adsf server.
            /// E.g. adfs.resourcedomain.com</summary>
            public string ResourcesTokenIssuerServer { get; set; }
    
        }
    
        /// <summary> Parameters to get token for your application  from resource ADFS 
        /// using token from partner's ADFS</summary>
        public class AdfsResourceProviderTokenForAppRequest
        {
            /// <summary>Token recieved from identity provider. </summary>
            public SecurityToken IpToken { get; set; }
            /// <summary>Resources token issuer server, i.e. your company adsf server.
            /// E.g. adfs.resourcedomain.com</summary>
            public string ResourcesTokenIssuerServer { get; set; }
            /// <summary>Apllication you want token for. In terms of ADFS its Relying Party.
            /// E.g. https://myAppServer.MyAppDomain.com/MyWcfService1 </summary>
            public string AppUrl { get; set; }
    
        }
    
        public class AdfsTokenFactory
        {
    
            public SecurityToken GetIpToken(AdfsIdentityProviderTokenRequest request)
            {
    
                //string username, string password, string tokenIssuer, string appliesTo, out 
    
                var binding = new WS2007HttpBinding();
                binding.Security.Message.EstablishSecurityContext = false;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
    
    
                var tokenIssuerUrlFormat = "https://{0}/adfs/services/trust/13/usernamemixed";
                var tokenIssuerUrl = string.Format(tokenIssuerUrlFormat, request.IpTokenIssuerServer);
    
    
                using (var factory = new WSTrustChannelFactory(binding, new EndpointAddress(tokenIssuerUrl)))
                {
                    factory.TrustVersion = TrustVersion.WSTrust13;
                    factory.Credentials.UserName.UserName = request.IpDomainUserName;
                    factory.Credentials.UserName.Password = request.IpDomainUserPassword;
    
                    factory.ConfigureChannelFactory();
    
    
                    var trustUrlFromat = "http://{0}/adfs/services/trust";
                    var trustUrl = string.Format(trustUrlFromat, request.ResourcesTokenIssuerServer);
    
                    var requestToken = new RequestSecurityToken(WSTrust13Constants.RequestTypes.Issue);
                    requestToken.AppliesTo = new EndpointAddress(trustUrl);
    
                    var tokenClient = (WSTrustChannel) factory.CreateChannel();
                    RequestSecurityTokenResponse rsts;
                    var token = tokenClient.Issue(requestToken, out rsts);
                    return token;
                }
    
            }
    
    
            public  SecurityToken GetResourceTokenForApp(AdfsResourceProviderTokenForAppRequest request)
            {
                var binding = new WS2007FederationHttpBinding();
                binding.Security.Message.IssuedKeyType = SecurityKeyType.SymmetricKey;
                binding.Security.Message.EstablishSecurityContext = false;
                binding.Security.Mode = WSFederationHttpSecurityMode.TransportWithMessageCredential;
    
                var tokenIssuerUrlFormat = "https://{0}/adfs/services/trust/13/IssuedTokenMixedSymmetricBasic256";
                var tokenIssuerUrl = string.Format(tokenIssuerUrlFormat, request.ResourcesTokenIssuerServer);
                using (var factory = new WSTrustChannelFactory(binding, new EndpointAddress(new Uri(tokenIssuerUrl))))
                {
                    var rst = new RequestSecurityToken
                    {
                        RequestType = WSTrust13Constants.RequestTypes.Issue,
                        AppliesTo = new EndpointAddress(request.AppUrl),
                        KeyType = WSTrust13Constants.KeyTypes.Symmetric,
                    };
                    factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                    factory.TrustVersion = TrustVersion.WSTrust13;
                    factory.Credentials.SupportInteractive = false;
                    factory.ConfigureChannelFactory();
    
    
                    var channel = factory.CreateChannelWithIssuedToken(request.IpToken);
                    RequestSecurityTokenResponse rstr;
                    SecurityToken token = channel.Issue(rst, out rstr);
                    return token;
                }
            }
        }
    }
