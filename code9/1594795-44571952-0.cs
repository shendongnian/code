    public List<T> GetStuff()
    {
            List<T> Results = new List<T>();
            RestClient Client = new RestClient();
            RestRequest Req = ConfigureGetRequest(Endpoint);
            IRestResponse Resp = Client.Execute(Req);
    
            if (Resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Results = JsonConvert.DeserializeObject<List<T>>(Resp.Content, DeserializationSettings);
            }
            return Results;
        }
    }
