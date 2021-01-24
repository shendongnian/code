    internal static Exception StatusException(int status)
    {
        Debug.Assert(status != Ok, "Throwing an exception for an 'Ok' return code");
    
        switch (status)
        {
            case GenericError: return new ExternalException(SR.GetString(SR.GdiplusGenericError), E_FAIL);
            case InvalidParameter: return new ArgumentException(SR.GetString(SR.GdiplusInvalidParameter));
            case OutOfMemory: return new OutOfMemoryException(SR.GetString(SR.GdiplusOutOfMemory));
            case ObjectBusy: return new InvalidOperationException(SR.GetString(SR.GdiplusObjectBusy));
            .....
         }
    }
