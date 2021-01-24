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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RestSharp;
    
    namespace RestServiceInvoker
    {
        public class RestEndPointInvoker : IRestEndPointInvoker 
        {               
            public RestEndPointInvoker()
            {
                _httpClient = new RestClient();        
            }
    
            /// <summary>
            /// Creates the RestClient object
            /// </summary>
            /// <returns></returns>
            private void BuildClient(RestClientRequest request)
            {          
                    //Set the  headers             
                    foreach (var header in request._requestHeaders)
                    {
                        _httpClient.AddDefaultHeader(header.Key, header.Value);
                    }                
            }
    
            /// <summary>
            /// Generic method to invoke Get methods on a Rest endpoint
            /// </summary>
            /// <returns></returns>
            public async Task<IRestResponse<T>> GetAsync<T>(RestClientRequest request) where T: new()
            {
                //Build the client object
                BuildClient(request);
    
                //Build request object
                var restRequest = BuildReqestObject(request);
    
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
    
    
            /// <summary>
            /// Adds the input parameters to the request object
            /// </summary>
            /// <returns></returns>
            private RestRequest BuildReqestObject(RestClientRequest requestObj)
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
                    @"{\"TheContentAreas\":[{\"ControlTypeID\":\"230c5669-aa0d-41bc-9069-559b5e7d0ece\",\"PlaceholderID\":\"a16a471e-9416-43fc-8ceb-fddb97509e0c\"}]}";
    
           
                request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
    
              
                return request;
            }
    
        }
    }
