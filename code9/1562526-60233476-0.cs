    using Newtonsoft.Json;
    public IActionResult Get([FromQuery(Name = "array")] string arrayJson)
    {
        List<string> array = JsonConvert.DeserializeObject<List<string>>(arrayJson);
    }
