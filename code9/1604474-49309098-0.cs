    using Microsoft.PowerBI.Api.V2;
    ...
    var tokenCredentials = new TokenCredentials(_authenticationResult.AccessToken, "Bearer");
    using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
    {
      string data = @"{  ""rows"":  
                                    [
                                        { ""id"": 1, ""name"": ""Tom""},                                
                                        { ""id"": 2, ""name"": ""Jerry""}
                                    ]
                                }";
      var dataJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data.ToString());
      client.Datasets.PostRowsInGroup(groupId, datasetId, tableName, datajson);
    }
