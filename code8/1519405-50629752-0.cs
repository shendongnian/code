        private GenericXmlSecurityToken NewGetAdfsSamlTokenWinAuth()
        {
            try
            {
                WS2007HttpBinding binding = new WS2007HttpBinding(SecurityMode.Transport);
                binding.Security.Message.EstablishSecurityContext = false;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                WSTrustChannelFactory factory = new WSTrustChannelFactory((binding), new EndpointAddress(this.adfsIntegratedAuthUrl));
                factory.TrustVersion = TrustVersion.WSTrustFeb2005;
                factory.Credentials.SupportInteractive = false;
                var rst = new RequestSecurityToken
                {
                    RequestType = RequestTypes.Issue,
                    AppliesTo = new EndpointReference("urn:federation:MicrosoftOnline"),
                    KeyType = KeyTypes.Bearer
                };
                IWSTrustChannelContract channel = factory.CreateChannel();
                return channel.Issue(rst) as GenericXmlSecurityToken;
            }
            catch (Exception ex)
            {
                // Do something with the exception
            }
            return null;
        }
