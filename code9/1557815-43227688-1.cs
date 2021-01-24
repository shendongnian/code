    public delegate double CallbackDelegate(double x);
    
    // PInvoke for the native DLL function
    [DllImport("YourDLL.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern double TestDelegate(CallbackDelegate func);
    
    private double MyFunctionCallback(double x)
    {
        // ... Implement your C# callback code ...
    }
    
    CallbackDelegate managedDelegate = new CallbackDelegate(MyFunctionCallback);
    
    // Call into the native DLL, passing the managed callback
    TestDelegate(managedDelegate);
