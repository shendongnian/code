    public void GetResponse() {
            var client = new RestClient("api-url-here");
            var req = new RestRequest("endpoint-here",Method.POST);
            var config = new ClientConfig();//values to pass in request
            // Content type is not required when adding parameters this way
            // This will also automatically UrlEncode the values
            req.AddParameter("client_id",config.client_id, ParameterType.GetOrPost);
            req.AddParameter("grant_type",config.grant_type, ParameterType.GetOrPost);
            req.AddParameter("client_secret",config.client_secret, ParameterType.GetOrPost);
            req.AddParameter("scope",config.scope, ParameterType.GetOrPost);
            req.AddParameter("response_type",config.response_type, ParameterType.GetOrPost);
    
            var res = client.Execute(req);
            return;
    }
