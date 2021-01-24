    [Serializable]
    public struct FuncResult
    {
    	public string MainResponse;
    	public string[] ExtraArgsForMagicFunction;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static FuncResult TestFunc(string val)
    {
    	return new FuncResult()
    	{
    		MainResponse = val + "Response",
    		ExtraArgsForMagicFunction = new[] { "Some Extra Args" }
    	};
    }
