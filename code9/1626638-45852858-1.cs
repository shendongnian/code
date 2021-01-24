    var auth = new SHA1AuthenticationProvider(new OctetString("myauthenticationpassword"));
    var priv = new DESPrivacyProvider(new OctetString("myprivacypassword"), auth);
    GetRequestMessage request = new GetRequestMessage(VersionCode.V3, Messenger.NextMessageId, Messenger.NextRequestId, new OctetString("myname"), new List<variable>{new Variable(new ObjectIdentifier("1.3.6.1.2.1.1.1.0"))}, priv, Messenger.MaxMessageSize, report);
   
    ISnmpMessage reply = request.GetResponse(60000, new IPEndPoint(IPAddress.Parse("192.168.1.2"), 161));
