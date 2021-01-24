    public enum Protocol
    {
    	Version1,
    	Version1A,
    	Version2
    }
    
    public IDeviceProtocol CreateDeviceProtocol(Protocol protocol)
    {
    	switch protocol
    	{
    		case Protocol.Version1:
    			return new Device1();
    			break;
    		case Protocol.Version1A:
    			return new Device1A();
    			break;
    		case Protocol.Version2:
    			return new Device2();
    			break;
    		default:
    			//throw some error	
    	}
    }
