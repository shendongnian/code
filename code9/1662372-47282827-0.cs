    [HttpPut]
    public HttpResponseMessage Put(int id)
    {
      HttpContent requestContent = Request.Content;
      string jsonContent = requestContent.ReadAsStringAsync().Result;
      entityclass obj= JsonConvert.DeserializeObject<entityclass>(jsonContent);
      ...
    }
