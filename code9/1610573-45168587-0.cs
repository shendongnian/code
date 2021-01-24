    public class StatusArgs : EventArgs
    {
    	public enum StatusEnum
    	{
    		ON,
    		WAIT,
    		OFF
    	}
    	public StatusEnum Status { get; set; }
    }
