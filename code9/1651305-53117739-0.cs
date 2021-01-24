    [TypeFilter(typeof(LogFilter), Arguments = new object[] {"myLogger"})]  
    [HttpGet("")]
    public IEnumerable<Item> Get()
    {
        return this.repository.GetAll();
    }
