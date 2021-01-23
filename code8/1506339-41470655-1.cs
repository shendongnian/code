    public object AfterReceiveRequest(ref Message request, IClientChannel channel,
       InstanceContext instanceContext) {
       try {
          using( var rdr = new MessageReader(ref request) ) {
    
             var value= rdr.ReadSomething( someIdentifier );
             return value;
          }
       }
       catch( System.Exception ex ) {
    
          throw CreateFault( ex, request );
       }
    }
