    [HttpGet]
    public async Task<IHttpActionResult> SearchCities(
        List<string> risks,
        List<string> ratings)
    {
        var results = this.dbContext.Cities.AsQueryable();
        if(risks.Any()) 
        {
            results = results.Where(c => c.Risks.Any(cr => risks.Contains(cr.Code));
        }
        if(ratings.Any())
        {
            results = results.Where(c => ratings.Contains(c.Rating));
        }
        ...
    }
