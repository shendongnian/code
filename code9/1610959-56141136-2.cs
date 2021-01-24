 
    [FunctionName("PostParameterFunction")]
    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
       {
          log.LogInformation("C# HTTP trigger function processed a request.");
    
           try
            {
                 // Convert all request perameter into Json object
    
                    var content = req.Content;
                    string jsonContent = content.ReadAsStringAsync().Result;
                    dynamic requestPram = JsonConvert.DeserializeObject<RequestModel>(jsonContent);
    
                    // Validate the required param
    
                    if (string.IsNullOrEmpty(requestPram.FirstName))
                    {
                        return req.CreateResponse(HttpStatusCode.OK, "Please enter First Name!");
                    }
                    if (string.IsNullOrEmpty(requestPram.LastName))
                    {
                        return req.CreateResponse(HttpStatusCode.OK, "Please enter Last Name!");
                    }
    
    
                    //Create object for partner Model to bind the response on it
    
                    RequestModel objRequestModel = new RequestModel();
    
                    objRequestModel.FirstName = requestPram.FirstName;
                    objRequestModel.LastName = requestPram.LastName;
    
                    //Return Request Model
    
                    return req.CreateResponse(HttpStatusCode.OK, objRequestModel);
             }
            catch (Exception ex)
             {
    
                    return req.CreateResponse(HttpStatusCode.OK, "Cannot Create Request! Reason: {0}", string.Format(ex.Message));
             }
            }
