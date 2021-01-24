    [ReturnValueTuple]
    [HttpGet]
    [Route("types")]
    public IEnumerable<(int id, string name)> GetDocumentTypes()
    {
        return ServiceContainer.Db
            .DocumentTypes
            .AsEnumerable()
            .Select(dt => (dt.Id, dt.Name));
    }
