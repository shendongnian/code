    [HttpGet]   
    public IHttpActionResult Get()
    {
        using (DatabaseEntities entities = new DatabaseEntities())
        {
            return Ok(entities.Aliases.ToList());
        }
    }
    public IHttpActionResult Get(int id)
    {
        using (DatabaseEntities entities = new DatabaseEntities())
        {
             return Ok(entities.Aliases.FirstOrDefault(a => a.ID == id));
        }
    }
