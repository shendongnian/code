    public List<Donut> GetDonuts<T>()
    {
        GET MakeCall = new GET();
        List<Donut> Results = new List<Donut>();
        Results = MakeCall.Index<Donut>();
        return Results;
    }
    public List<T> Index<T>()
    {
        T Result;
        List<T> ResultList = new List<T>();
        RestClient Client = new RestClient();
        RestRequest Req = ConfigureGetRequest(Endpoint);
        IRestResponse Resp = Client.Execute(Req);
        if (Resp.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Result = JsonConvert.DeserializeObject<T>(Resp.Content, DeserializationSettings);
            ResultList.Add(Result);
        }
        return ResultList;
    }
