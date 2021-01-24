    public static async Task<string> GetAccessToken(string authority, string resource, string clientId)
        {
           
            var certPath = Path.Combine(GetCurrentDirectoryFromExecutingAssembly(), "mycertificate.pfx");
            var certfile = File.OpenRead(certPath);
            var certificateBytes = new byte[certfile.Length];
            certfile.Read(certificateBytes, 0, (int)certfile.Length);
            var cert = new X509Certificate2(
                certificateBytes,
                "PASSWORD",
                X509KeyStorageFlags.Exportable |
                X509KeyStorageFlags.MachineKeySet |
                X509KeyStorageFlags.PersistKeySet);
            var factory = new WSTrustChannelFactory(
                new CertificateWSTrustBinding(
                    SecurityMode.TransportWithMessageCredential),
                "https://example.com/adfs/services/trust/13/certificatemixed") {TrustVersion = TrustVersion.WSTrust13};
            if (factory.Credentials != null)
                factory.Credentials.ClientCertificate.Certificate = cert;
            // create token request  
            var rst = new RequestSecurityToken
            {
                RequestType = RequestTypes.Issue,
                KeyType = KeyTypes.Bearer,
                AppliesTo = new EndpointReference("http://example.com/api"),
                KeySizeInBits = 0,
                TokenType = "urn:ietf:params:oauth:token-type:jwt"
            };
            // request token and return
            var genericXmlSecurityToken = factory.CreateChannel().Issue(rst) as GenericXmlSecurityToken;
            return genericXmlSecurityToken != null 
                ? Encoding.UTF8.GetString(Convert.FromBase64String(genericXmlSecurityToken.TokenXml.InnerXml)) 
                : string.Empty;
        }
