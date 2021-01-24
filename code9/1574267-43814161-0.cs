    //DECLARE THE FUNCTION FROM DLL
    [DllImport(<<YOUR DLL>>,CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    public static extern void dllFunctionGetList(IntPtr[] ListOfStrs);
    
    //GET THE LIST OF STRINGS
    IntPtr[] parameterNames = new IntPtr[100];
    dllFunctionGetList(parameterNames);
    
    int i = 0;
    IntPtr ptr;
    
    //ITERATE THE STRINGS
    while ((ptr = (IntPtr)parameterNames[i]) != IntPtr.Zero)
    {
        Console.WriteLine(Marshal.PtrToStringAnsi(ptr));
        i++;
    }
