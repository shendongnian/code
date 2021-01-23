    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using RestSharp;
    
    public async Task<SomeObject> TestPost(ObjectFoo foo)
    {
    	JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { 
    	ContractResolver = new CamelCasePropertyNamesContractResolver() 
    	};
    	
    	RestClient restClient = new RestClient(API_URL);
    	RestRequest request = new RestRequest("SOME_METHOD", Method.POST);
    	request.AddHeader("Accept", "application/json");
    	
    	string jsonObject = JsonConvert.SerializeObject(foo, Formatting.Indented, jsonSerializerSettings);
    	request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
    	
    	TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
    	
    	RestRequestAsyncHandle handle = restClient.ExecuteAsync(
    		request, r => taskCompletion.SetResult(r));
    		
    	RestResponse response = (RestResponse)(await taskCompletion.Task);
    	
    	return JsonConvert.DeserializeObject<SomeObject>(response.Content);
    }
