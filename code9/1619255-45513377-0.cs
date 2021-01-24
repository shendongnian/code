    public static Encoding OutputEncoding {
        [System.Security.SecuritySafeCritical]  // auto-generated
        get {
                
            Contract.Ensures(Contract.Result<Encoding>() != null);
 
            if (null != _outputEncoding)
                return _outputEncoding;
 
            lock(InternalSyncObject) {
 
                if (null != _outputEncoding)
                    return _outputEncoding;
                   
                uint cp = Win32Native.GetConsoleOutputCP();
                _outputEncoding = Encoding.GetEncoding((int) cp);
                return _outputEncoding;
            }
        }
        ...
