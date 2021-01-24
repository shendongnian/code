            var token = new TokenValidation()
            {
                   app_id = CloudConfigurationManager.GetSetting("appId"),
                   secret = CloudConfigurationManager.GetSetting("secret"),
                   grant_type = CloudConfigurationManager.GetSetting("grant_type"),
                   Username = CloudConfigurationManager.GetSetting("Username"),
                   Password = CloudConfigurationManager.GetSetting("Password"),
            };
            var client = new RestClient($"{xxx}{tokenEndPoint}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"app_id={token.app_id}&secret={token.secret}&grant_type={token.grant_type}&Username={token.Username}&Password={token.Password}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Access Token cannot obtain, process terminate");
                return null;
            }
            var tokenResponse = JsonConvert.DeserializeObject<TokenValidationResponse>(response.Content);
