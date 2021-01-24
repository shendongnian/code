	[HubName("OpenHub")]
	public class OpenHub:Hub
	{
	    public void DetermineLength(string message)
	    {
	        Clients.All.RecieveNewInfo(newMessage);
	        Program.MainForm.lstMessages.Add(newMessage);
	    }
	}	
