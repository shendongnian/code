    using (OperationContextScope scope = new OperationContextScope((IContextChannel)channel))
    {
        MessageHeader<string> header = new MessageHeader<string>("MyHttpHeaderValue");
        var untyped = header.GetUntypedHeader("User-Auth", ns);
        OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
    
        // now make the WCF call within this using block
    }
    
