    public class ADFSUsernameMixedTokenProvider
    {
        private readonly Uri adfsUserNameMixedEndpoint;
        /// <summary>
        /// Initializes a new instance of the <see cref="ADFSUsernameMixedTokenProvider"/> class
        /// </summary>
        /// <param name="adfsUserNameMixedEndpoint">i.e. https://adfs.mycompany.com/adfs/services/trust/13/usernamemixed </param>
        public ADFSUsernameMixedTokenProvider(Uri adfsUserNameMixedEndpoint)
        {
            this.adfsUserNameMixedEndpoint = adfsUserNameMixedEndpoint;
        }
        /// <summary>
        /// Requests a security token from the ADFS server
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="endpoint">The ADFS endpoint</param>
        /// <returns></returns>
        public GenericXmlSecurityToken RequestToken(string username, SecureString password, string endpoint)
        {
            WSTrustChannelFactory factory = new WSTrustChannelFactory(
                    new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                     new EndpointAddress(adfsUserNameMixedEndpoint));
            factory.TrustVersion = TrustVersion.WSTrust13;
            factory.Credentials.UserName.UserName = username;
            factory.Credentials.UserName.Password = new System.Net.NetworkCredential(string.Empty, password).Password;
            RequestSecurityToken token = new RequestSecurityToken
            {
                RequestType = RequestTypes.Issue,
                AppliesTo = new EndpointReference(endpoint),
                KeyType = KeyTypes.Bearer
            };
            IWSTrustChannelContract channel = factory.CreateChannel();
            return channel.Issue(token) as GenericXmlSecurityToken;
        }
    }
