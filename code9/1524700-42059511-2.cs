    public static class ProtoParser
    {
    	public static ProtoMessage TryParse(byte[] bytes)
    	{
    		return null;
    	}
    }
    
    public class ClientSession<TMessage>
    {
    	Func<byte[], TMessage> _parser;
    	public ClientSession(Func<byte[], TMessage> parser)
    	{
    		_parser = parser;
    	}
    	
    	public TMessage OnMessageReceived(Object sender, MessageEventArgs e)
    	{
    		return _parser(e.bytes);
    	}
    }
