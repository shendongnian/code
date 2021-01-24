    [HttpGet("{id:int}")]
    public string GetById(int id)
    {
       return id.ToString();
    }
    [HttpGet("{name}")]
    public string GetByName(string name)
    {
       return name + " name";
    }
