    public interface IMessageSender
    {
    	void SendMessage();
    }
    public class EmailSender : IMessageSender
    {
    	public void SendMessage()
    	{
    		Console.WriteLine(MessageText());
    	}
    	private string MessageText()
    	{
    		return "Message to send !";
    	}
    		
    }
    public class SmsSender : IMessageSender
    {
    	public void SendMessage()
    	{
    		Console.WriteLine(MessageText());
    	}
    	
    	private string MessageText()
    	{
    		return "Message to send !";
    	}
    }
