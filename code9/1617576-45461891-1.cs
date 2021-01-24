    [HttpPost]
    public async Task<string> Post([FromBody]JObject value)
    {
      if (MesureController.CheckJsonIntegrity<Mesure>(value))
      {
        return await MesureAsync(value);
      }
      return null;
    }
