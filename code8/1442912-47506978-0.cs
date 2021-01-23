    using System.IdentityModel.Tokens;
    using Microsoft.IdentityModel.Protocols.WSTrust;
    using System.ServiceModel;
    using System.ServiceModel.Security;
    using WSTrustChannel = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel;
    using WSTrustChannelFactory = Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory;
    
    
    namespace SOS.Tools.AdfsConnectionChecker
    
    {
        internal class Token
    
        {
    
            public static SecurityToken GetToken(string username, string password, string tokenIssuer, string appliesTo, out RequestSecurityTokenResponse rsts)
    
            {
                WS2007HttpBinding binding = new WS2007HttpBinding();
                binding.Security.Message.EstablishSecurityContext = false;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
    
    
                var tokenIssuerUrlFormat = "https://{0}/adfs/services/trust/13/usernamemixed";
                var tokenIssuerUrl = string.Format(tokenIssuerUrlFormat, tokenIssuer);
    
    
                WSTrustChannelFactory trustChannelFactory =
                    new WSTrustChannelFactory(binding, new EndpointAddress(tokenIssuerUrl));
    
                trustChannelFactory.TrustVersion = TrustVersion.WSTrust13;
                trustChannelFactory.Credentials.UserName.UserName = username;
                trustChannelFactory.Credentials.UserName.Password = password;
    
                trustChannelFactory.ConfigureChannelFactory();
    
    
    
                // Create issuance issuance and get security token 
                RequestSecurityToken requestToken = new RequestSecurityToken(WSTrust13Constants.RequestTypes.Issue);
                requestToken.AppliesTo = new EndpointAddress(appliesTo);
    
                WSTrustChannel tokenClient = (WSTrustChannel) trustChannelFactory.CreateChannel();
                SecurityToken token = tokenClient.Issue(requestToken, out rsts);
                return token;
    
            }
    }
