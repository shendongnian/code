    var myServiceClient = new MyServiceClient(); // reads from configuration file
    if (Debugger.IsAttached)
    {   // Increase timeouts to enable slow debugging:
	    IContextChannel contextChannel = (IContextChannel)myServiceClient.InnerChannel;
		// InnerChannel is of type IClientChannel, which implements IContextChannel
		
		// set the operation timeout to a long value, for example 3 minutes:
        contextChannel.OperationTimeout = TimeSpan.FromMinutes(3);
    }
    return (IMyInterface)myService;
