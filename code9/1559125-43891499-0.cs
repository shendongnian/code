    public class PasswordDigestBehavior : IEndpointBehavior
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public PasswordDigestBehavior(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // do nothing
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            //clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
            clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            throw new NotImplementedException();
        }
        public void Validate(ServiceEndpoint endpoint)
        {
            // do nothing...
        }
    }
    public class PasswordDigestMessageInspector : IClientMessageInspector
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public PasswordDigestMessageInspector(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // do nothing
        }
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            // Use the WSE 3.0 security token class
            var option = PasswordOption.SendHashed;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                option = PasswordOption.SendPlainText;
            UsernameToken token = new UsernameToken(this.Username, this.Password, option);
            // Serialize the token to XML
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement securityToken = token.GetXml(xmlDoc);
            // find nonce and add EncodingType attribute for BSP compliance
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsMgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            XmlNodeList nonces = securityToken.SelectNodes("//wsse:Nonce", nsMgr);
            XmlAttribute encodingAttr = xmlDoc.CreateAttribute("EncodingType");
            encodingAttr.Value = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";
            if (nonces.Count > 0)
            {
                nonces[0].Attributes.Append(encodingAttr);
                //nonces[0].Attributes[0].Value = "foo";
            }
            //
            MessageHeader securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);
            request.Headers.Add(securityHeader);
            // complete
            return Convert.DBNull;
        }
    }
