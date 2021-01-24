    public static List<Sales> getByIdWebService( string id )
    {
    	List<Sales> list = null;
    
    	using ( WcfSvcRefAsWsdl.ClientWsClient wsdlClient = new WcfSvcRefAsWsdl.ClientWsClient() )
    	{
    		// The following will not compile
    		// DtoClassLib.Client returnClient = wsdlClient.getClientByID( id );
    	}
    
    	using ( WcfSvcRef.ClientWsClient wcfClient = new WcfSvcRef.ClientWsClient() )
    	{
    		// Joy!  \o/
    		DtoClassLib.Client client = wcfClient.getClientByID( id );
            list = client.listSales;
    	}
    
    	return list;
    }
