    [HttpPost]
    public async Task<string> Post([FromBody] ResponseObject request) {
      // Do work
      ResponseObject response = ...
      // I am using Jil here, but you could also use Json.NET
      return JSON.SerializeDynamic(response);
      // return JsonConvert.SerializeObject(response);
    }
