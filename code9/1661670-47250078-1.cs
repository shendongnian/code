     SAMLConfigurationFile.Load();
     string partnerSP = null;
                    SSOOptions options = null;
                    SAMLIdentityProvider.ReceiveSSO(Request, out partnerSP, out options);
           string userName = "robert@test.com";
     IDictionary<string, string> attributes = new Dictionary<string, string>();
      attributes.Add("NameID", "robert@test.com"); // as an example for possible attribute
    
        SAMLIdentityProvider.SendSSO(Response, userName, attributes);
