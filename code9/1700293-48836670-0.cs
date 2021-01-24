    private static bool CheckAllowGetStorePrivateDataClassAccess<TEcho, TKey>()
    {
		var trace = new StackTrace();
		var callingFrame = trace.GetFrame(2);
		var callingClass = callingFrame.GetMethod().DeclaringType;
		return callingClass == typeof(EchoProcess);
    }
