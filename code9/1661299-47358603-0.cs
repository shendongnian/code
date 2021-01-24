    var pNames = object_get_prop_names(hdl);
    if (h == IntPtr.Zero)
    {
        return null;
    }
    var nameList = new List<string>();
    int elementSize = Marshal.SizeOf(typeof(IntPtr));
    for (int i = 0; i < 200; i++) //don't know length, pick large number
    {
        var ptr = Marshal.ReadIntPtr(pNames, i * elementSize);
        var str = Marshal.PtrToStringAnsi(ptr);
        if (!string.IsNullOrWhiteSpace(str))
        {
            nameList.Add(str);
        }
        else //end of pNames
        { 
            break; 
        }
    }
