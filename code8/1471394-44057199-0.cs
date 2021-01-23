    public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
    {
    	NetworkInterface result = null;
    	var cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
    	if (cards.Any())
    	{
    		foreach (var card in cards.Where(a => a.OperationalStatus == OperationalStatus.Up))
    		{
    			var props = card.GetIPProperties();
    			if (props == null)
    				continue;
    
    			var gateways = props.GatewayAddresses;
    			if (!gateways.Any())
    				continue;
    
    
    			var gateway =
    				gateways.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
    			if (gateway == null)
    				continue;
    
    
    			result = card;
    
    			break;
    		};
    	}
    
    	return result;
    }
