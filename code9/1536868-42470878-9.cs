    [Route("api/{tenantId}/Values/Get")]
    [HttpGet]
    public IEnumerable<string> Get()
    {
        _testService.DoDatabaseWork();
        return new string[] { "value1", "value2" };
    }
