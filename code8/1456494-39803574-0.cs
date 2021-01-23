	public delegate void CallbackDelegate(string message);
	[MethodImplAttribute(MethodImplOptions.InternalCall)]
	public static extern void setCallback(IntPtr aCallback);
    public string name = "test";
    private CallbackDelegate del; 
    public void testCallbacks()
    {
    	System.Console.Write("Registering C# callback...\n");
    	name = "test22";
    	del = new CallbackDelegate(callback01);
    	setCallback(Marshal.GetFunctionPointerForDelegate(del));
    
    	System.Console.Write("Calling passed C++ callback...\n");
    }
    
    public void callback01(string message)
    {
    	System.Console.Write("callback 01 called. Message: " + message + " Printed from: " + name + "\n");
    }
