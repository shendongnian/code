    public class FooServiceClient : IFooService
    {
        private readonly RestClient _restClient;
        public FooServiceClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl.TrimEnd('/'));
        }
        public FooDto GetFoo(Guid id)
        {
            var request = new RestRequest($"api/foo/get{id}", Method.GET);
            var foo = _restClient.Execute<FooDto>(request).Data;
            return foo;
        }
        public List<FooDto> GetAllFoos()
        {
            var request = new RestRequest("api/foo/getall", Method.GET);
            var foos = _restClient.Execute<List<FooDto>>(request).Data;
            return foos;
        }
        public Guid InsertFoo(FooInsertDto foo)
        {
            var request = new RestRequest("api/foo/insert", Method.POST)
                { RequestFormat = DataFormat.Json};
            request.AddBody(foo);
            return _restClient.Execute<Guid>(request).Data;
        }
        public void UpdateFoo(FooDto updating)
        {
            var request = new RestRequest("api/foo/update", Method.POST)
            { RequestFormat = DataFormat.Json };
            request.AddBody(updating);
            _restClient.Execute(request);
        }
        public void DeleteFoo(Guid id)
        {
            var request = new RestRequest("api/foo/delete", Method.POST)
            { RequestFormat = DataFormat.Json };
            request.AddBody(id);
            _restClient.Execute(request);
        }
    }
