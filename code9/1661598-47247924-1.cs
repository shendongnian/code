    public abstract class MessageSender
    {
    	public abstract void SendMessage();
    	
    	protected string MessageText()
    	{
    		return "Message to send !";
    	}
    }
    public class EmailSender : MessageSender
    {
    	public override void SendMessage()
    	{
    		Console.WriteLine(MessageText());
    	}
    		
    }
    public class SmsSender : MessageSender
    {
    	public override void SendMessage()
    	{
    		Console.WriteLine(MessageText());
    	}
    }
