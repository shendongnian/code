    public void ApplyTo(IDictionary<string, string> parameters)
    {
    	secureLock.WaitOne();
    
    	// We don't want to blow up if ApplyTo is called multiple times.
    	if (IsApplied)
    		return;
    
    	IntPtr ptr = IntPtr.Zero;
    
    	try
    	{
    		ptr = Marshal.SecureStringToCoTaskMemUnicode(secureString);
    		parameters[OAuthParameter.ClientSecret] = Marshal.PtrToStringUni(ptr);
    	}
    	finally
    	{
    		if (ptr != IntPtr.Zero)
    			Marshal.ZeroFreeCoTaskMemUnicode(ptr);
    
    		if (secureString != null && !secureString.IsReadOnly())
    			secureString.Clear();
    
    		secureString = null;
    
    		secureLock.Set();
    	}            
    }
