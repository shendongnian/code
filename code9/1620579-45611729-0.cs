    void MyMethod()
    {
      using (var proxy = new WcfProxy())
      {
        using (var scope = new OperationContextScope((IContextChannel)proxy))
        {
          MessageHeader header = MessageHeader.CreateHeader("VERSION_HEADER", "ns", SerializeVersion());
          OperationContext.Current.OutgoingMessageHeaders.Add(header); 
    
          proxy.ExecuteOperation() // Call you service
        }
      }
    }
