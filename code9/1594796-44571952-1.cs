    public List<T> GetStuff<T>(string endpoint)
    {
            List<T> Results = new List<T>();
            RestClient Client = new RestClient();
            RestRequest Req = ConfigureGetRequest(endpoint);
            IRestResponse Resp = Client.Execute(Req);
    
            if (Resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Results = JsonConvert.DeserializeObject<List<T>>(Resp.Content, DeserializationSettings);
            }
            return Results;
        }
    }
