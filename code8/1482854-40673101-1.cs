    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public PasswordDigestMessageInspector(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
        // do nothing
    }
    
    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
    {
        // generate token
        var usernameToken = new UsernameToken(this.Username, this.Password, PasswordOption.SendHashed);
    
        // save token as xml
        var securityToken = usernameToken.GetXml(new XmlDocument());
        var securityTokenText = securityToken.OuterXml;
    
        // remove vs data
        var limit = request.Headers.Count;
        for (var i = 0; i < limit; ++i)
        {
            if (!request.Headers[i].Name.Equals("VsDebuggerCausalityData")) continue;
    
            request.Headers.RemoveAt(i);
            break;
        }
    
        // set encoding type for nonce
        var nonceRegex = new Regex(@"<wsse:Nonce");
        securityTokenText = nonceRegex.Replace(securityTokenText,
            "<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\"");
    
        var newDoc = new XmlDocument();
        newDoc.LoadXml(securityTokenText);
    
        // create security header from message
        var securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", newDoc.DocumentElement, false);
    
        // add header to request message
        request.Headers.Add(securityHeader);
    
        // complete
        return Convert.DBNull;
    }
