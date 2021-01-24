    var strArray = new byte[100][];
            
    for (int i = 0; i < strArray.Length; i++) 
    {
        // 49 characters + NUL
        strArray[i] = new byte[50]; // or a size you choose
    }
    var handles = new GCHandle[strArray.Length];
    string[] strings;
    try 
    {
        var ptrs = new IntPtr[strArray.Length];
        for (int i = 0; i < strArray.Length; i++) 
        {
            handles[i] = GCHandle.Alloc(strArray[i], GCHandleType.Pinned);
            ptrs[i] = handles[i].AddrOfPinnedObject();
        }
        modifyStringInCpp(ptrs);
        strings = new string[strArray.Length];
        for (int i = 0; i < strArray.Length; i++) 
        {
            strings[i] = Marshal.PtrToStringAnsi(ptrs[i]);
        }
    } 
    finally 
    {
        for (int i = 0; i < strArray.Length; i++) 
        {
            if (handles[i].IsAllocated) 
            {
                handles[i].Free();
            }
        }
    }
