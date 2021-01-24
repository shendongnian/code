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
    
    public class ClientSession<TParser, TMessage> where TParser : MessageParser<TMessage>, new()
    {
    	TParser _parser = new TParser();
    
    	public TMessage OnMessageReceived(Object sender, MessageEventArgs e)
    	{
    		return _parser.TryParse(e.bytes);
    	}
    }
