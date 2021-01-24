            ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
            var rst = new RequestSecurityToken(RequestTypes.Issue);
            rst.AppliesTo = new EndpointReference("https://RelyingParty/*");
            rst.KeyType = KeyTypes.Bearer;
            rst.TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0";
            using (var trustChannelFactory = new WSTrustChannelFactory("WS2007HttpBinding_IWSTrust13_Saml20Sync"))
            {
                trustChannelFactory.Credentials.UserName.UserName = userName;
                trustChannelFactory.Credentials.UserName.Password = userPassword;
                var channel = (WSTrustChannel)trustChannelFactory.CreateChannel();
                try
                {
                    _authToken = channel.Issue(rst);
                }
                catch (MessageSecurityException ex)
                {
                    channel.Abort();
                    throw new SecurityTokenException(ex.InnerException.Message, ex);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                UserIdenity = CreateUserIdentityFromSecurityToken(_authToken);
            }
