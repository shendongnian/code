    //Main class calling the service invoker
	try
	{
		var _restMethodInvoker = new RestEndPointInvoker();
		var headers = new Dictionary<string, string>
		{
			{ "Authorization", "xxx" },
			{ "Session", "xxx" } ,
			{ "EncryptedKey", "xxx"}
		};
		var inputParameters = new Dictionary<string, string>
		{
			{ "Role", "MEMBER" },
			{ "SystemID", "xxx" } ,
			{ "Caller", "PREVIEW" } ,
			{ "Ticks", "1234" } ,
			{ "UserID", "TestUser" } ,
			{ "MemberId", "TestMEmber" }   
		var request1 = new RestClientRequest
		{
			_apiMethod = "TestServices/GetAll/{Role}/{SystemID}/{Caller}/{Ticks}/{UserID}/{MemberId}",
			_environmentType = "xx",
			_inputParameters = inputParameters,
			_requestHeaders = headers
		};
		var result1 = _restMethodInvoker.GetAsync<List<ReturnType>>(request1);
		var result = result1.Result;
	}
	catch (Exception ex)
	{
		throw ex;
	}
