    public abstract class MessageParser<TMessage>
    {
    	public abstract TMessage TryParse(byte[] bytes);
    }
    
    public class ProtoParser : MessageParser<ProtoMessage>
    {
    	public override ProtoMessage TryParse(byte[] bytes)
    	{
    		return null;
    	}
    }
    
    public class ClientSession<TParser, TMessage> where TParser : MessageParser<TMessage>
    {
    	TParser _parser;
    	public ClientSession(TParser parser)
    	{
    		_parser = parser;
    	}
    
    	public TMessage OnMessageReceived(Object sender, MessageEventArgs e)
    	{
    		return _parser.TryParse(e.bytes);
    	}
    }
