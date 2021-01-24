    [HttpPost]
    public string Post([FromBody]JObject value)
    {
      if (MesureController.CheckJsonIntegrity<Mesure>(value))
      {
        return await MesureAsync(value);
      }
      return null;
    }
