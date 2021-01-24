    [HttpGet]
    public async Task<HttpResponseMessage> GetUserData()
    {     
       var result = GetSomeData();
       var response = Request.CreateResponse();
       response.Content = new StringContent(JsonConvert.SerializeObject(result));
       return response;
    }
