    public class SafeHandleExtended : SafeHandle
    {
    	public void SetHandleExtended(IntPtr handle)
    	{
    		this.SetHandle(handle);
    	}
    
        // .. SafeHandle's abstract methods etc. that you need to implement
    }
