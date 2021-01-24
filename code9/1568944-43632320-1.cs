    [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getByteArray();
    
    [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int freeMem(IntPtr ptr);
    
    //Test
    void Start() {
     //Call and return the pointer
     IntPtr returnedPtr = getIntArray();
    
     //Create new Variable to Store the result
     byte[] returnedResult = new byte[2];
    
     //Copy from result pointer to the C# variable
     Marshal.Copy(returnedPtr, returnedResult, 0, 2);
    
     //Free native memory
     freeMem(returnedPtr);
    
     //The returned value is saved in the returnedResult variable
     byte val1 = returnedResult[0];
     byte val2 = returnedResult[1];
    }
