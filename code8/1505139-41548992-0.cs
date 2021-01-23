    var b = new CustomBinding();
    var security = TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement();
        security.IncludeTimestamp = true;
        security.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Default;
        security.MessageSecurityVersion = MessageSecurityVersion.Default;
        security.SecurityHeaderLayout = SecurityHeaderLayout.Lax;
        security.EnableUnsecuredResponse = true;
    var encoding = new TextMessageEncodingBindingElement();
        encoding.MessageVersion = MessageVersion.Soap12WSAddressing10;
        
    var transport = new HttpsTransportBindingElement
        {
           MaxBufferPoolSize = 2147483647,
           MaxBufferSize = 2147483647,
           MaxReceivedMessageSize = 2147483647,
        };
        b.Elements.Add(security);
        b.Elements.Add(encoding);
        b.Elements.Add(transport);
            
    var client = new MyClient(binding, addr);
    var result = client.Method(new MyObject());
