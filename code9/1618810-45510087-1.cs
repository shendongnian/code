    public static List<Sales> getByIdWebService( string id )
    {
    	List<Sales> list = null;
    
    	using ( WcfSvcRefAsWsdl.ClientWsClient wsdlClient = new WcfSvcRefAsWsdl.ClientWsClient() )
    	{
    		// The following will not compile
    		// DtoClassLib.Client returnClient = wsdlClient.getClientByID( "ABC123" );
    	}
    
    	using ( WcfSvcRef.ClientWsClient wcfClient = new WcfSvcRef.ClientWsClient() )
    	{
    		// Joy!  \o/
    		DtoClassLib.Client client = wcfClient.getClientByID( "ABC123" );
    	}
    
    	return list;
    }
