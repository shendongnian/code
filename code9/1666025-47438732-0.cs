    public static bool CheckNetwork()
    		{
    			if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
    			{
    				//Do your stuffs when network available
    				return true;
    
    			}
    			else
    			{
    				//When network not available,  
    				return false;
    			}
    		}
