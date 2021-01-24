    I spent some time working on it. Here is my solution - 
    Created a generic service invoker class and called it from my main class.
    
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
    
    
    
    --Rest Invoker class using restsharp
    namespace RestServiceInvoker
    {
        public class RestEndPointInvoker : IRestEndPointInvoker 
        {               
            public RestEndPointInvoker()
            {
                _httpClient = new RestClient();        
            }
    
          
            private void BuildRestClient(RestClientRequest request)
            {          
                    //Set the  headers             
                    foreach (var header in request._requestHeaders)
                    {
                        _httpClient.AddDefaultHeader(header.Key, header.Value);
                    }                
            }
    
          
            public async Task<IRestResponse<T>> GetAsync<T>(RestClientRequest request) where T: new()
            {
                //Build the client object
                BuildRestClient(request);
    
                //Build request object
                var restRequest = BuildRestReqestObject(request);
    
                //var response11 = _httpClient.Execute<T>(restRequest);
    
                var taskSource = new TaskCompletionSource<IRestResponse<T>>();
    
                //Execute the request
                _httpClient.ExecuteAsync<T>(restRequest, response =>
                 {
                     if (response.ErrorException != null)
                         taskSource.TrySetException(response.ErrorException);
                     else
                         taskSource.TrySetResult(response);
    
                 });
    
                return await taskSource.Task;
            }
    
    
          
            private RestRequest BuildRestReqestObject(RestClientRequest requestObj)
            {          
    
                var request = new RestRequest {Resource = requestObj._apiMethod};
    
                if (requestObj._inputParameters == null || requestObj._inputParameters.Count <= 0) return request;
    
                foreach (var inputParam in requestObj._inputParameters)
                {
                    request.AddParameter(inputParam.Key, inputParam.Value, ParameterType.UrlSegment);
                }
    
                request.Method = Method.POST;  //This could be parameterized from the client. For now we are only supporting get calls
    
    --This would be sent as input parameter. Just was lazy to hardcode it here
     string jsonToSend =
                    @"xxxxxxxxxxx";
    
           
                request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
    
              
                return request;
            }
    
        }
    }
