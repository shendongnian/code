        public GenericXmlSecurityToken GetToken()
        {
            WS2007HttpBinding binding = new WS2007HttpBinding(SecurityMode.Transport);
            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            WSTrustChannelFactory factory = new WSTrustChannelFactory((binding), new EndpointAddress(stsEndpoint));
            factory.TrustVersion = TrustVersion.WSTrustFeb2005;
            factory.Credentials.SupportInteractive = false;
            var rst = new RequestSecurityToken
            {
                RequestType = RequestTypes.Issue,
                AppliesTo = new EndpointReference(realm),
                KeyType = KeyTypes.Bearer
            };
            IWSTrustChannelContract channel = factory.CreateChannel();
            return channel.Issue(rst) as GenericXmlSecurityToken;
        }
