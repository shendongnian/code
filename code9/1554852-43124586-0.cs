    [ComImport]
    [Guid("xxx-yyy-zzz")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICOMInterfaceImp
    {
         [PreserveSig]
         int Create(string location, out CerberusErrorDetails details);
    }
