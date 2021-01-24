    // GET: api/messages/{name}
    [HttpGet("{name:string}")]
    public IEnumerable<Message> GetMessagesByName(string name)
    {
        return _repository.GetMessages().Where(m => m.Owner == name);
    } 
