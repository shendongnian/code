    [DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int dllFunction();
    public virtual int dllFunctionCaller()
    {
        return dllFunction();
    }
