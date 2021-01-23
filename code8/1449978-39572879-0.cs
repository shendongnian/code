               public class YourModel
                {
                    public string Doggy { get; set; }
                    public string Race { get; set; }
                    public string User { get; set; }
            
                }
                public YourModel nYModel = new YourModel();
                nYModel.Doggy = string1;
                nYModel.Race  = string2;
                nYModel.User = string3;
        
        var client = new RestClient(ServiceUrl);
        
        var request = new RestRequest("/resource/", Method.POST);
        
        // Json to post.
        string jsonToSend = JsonHelper.ToJson(nYModel);
        
        request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
        request.RequestFormat = DataFormat.Json;
        
        try
        {
            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // OK
                }
                else
                {
                    // NOK
                }
            });
        }
        catch (Exception error)
        {
            // Log
        }
