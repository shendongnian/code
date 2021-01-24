    [HttpGet]
    public IEnumerable<City> Cities([FromUri(Name ="countryCode")]int stateId)
    {
        using (ApplicationDbContext db = new ApplicationDbContext())
        {
            return db.Cities.Where(c => c.State.Id == stateId).OrderBy(o => o.Name).ToList();
        }
    }
