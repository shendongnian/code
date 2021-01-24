    public enum ErrorCodes
    {
    	E1,
    	E2,
    	S4,
    	P5
    }
    public class MyObjectTransferException : Exception
    {
    	public object ErrorCode { get; set; }
    
    	public MyObjectTransferException(string message, ErrorCodes code) : base(message)
    	{
    		this.ErrorCode = code;
    	}
    }
