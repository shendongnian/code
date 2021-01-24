    AsymmetricSecurityBindingElement asbe = new AsymmetricSecurityBindingElement
    {
      MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10, // Or WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10 ?
      InitiatorTokenParameters = new X509SecurityTokenParameters { InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient },
      RecipientTokenParameters = new X509SecurityTokenParameters(),
      SecurityHeaderLayout = SecurityHeaderLayout.Strict,
      IncludeTimestamp = true,
      DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128Rsa15,
      AllowSerializedSigningTokenOnReply = true
    };
    asbe.SetKeyDerivation(false); // What is it for?
    asbe.EndpointSupportingTokenParameters.Signed.Add(new X509SecurityTokenParameters { InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient });
    
    CustomBinding binding = new CustomBinding();
    binding.Elements.Add(asbe);
    binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
    binding.Elements.Add(new HttpsTransportBindingElement
    {
      MaxReceivedMessageSize = 1024 * 1024
    });
    
    Client.Endpoint.Binding = binding;
