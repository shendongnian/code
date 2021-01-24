    private object UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
    {
    	if (arguments == null || arguments.Length == 0)
    		return RuntimeMethodHandle.InvokeMethod(obj, null, Signature, false);
    	else
    	{
    		Object retValue = RuntimeMethodHandle.InvokeMethod(obj, arguments, Signature, false);
    
    		// copy out. This should be made only if ByRef are present.
    		for (int index = 0; index < arguments.Length; index++)
    			parameters[index] = arguments[index];
    
    		return retValue;
    	}
    }
