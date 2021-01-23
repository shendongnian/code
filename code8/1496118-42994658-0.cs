    // GET api/User/5
    [HttpGet]    
    [ResponseType(typeof(UserModel))]
    [Route("api/User/{id}")]
    public IHttpActionResult GetUser(Guid id)
    {
    	var item = repository.Get(id);    
    	if (item == null)
    	{
    		throw new HttpResponseException(HttpStatusCode.NotFound);
    	}
    	else
    	{
    		return Ok(item);
    	}
    }
    
    // GET api/User/GetCities/5
    [ResponseType(typeof(CityModel))]
    [Route("api/User/GetCities/{id}")]
    public IHttpActionResult GetCities(int id)
    {
    	var item = repository.GetCities(id);
    	if (item == null)
    	{
    		throw new HttpResponseException(HttpStatusCode.NotFound);
    	}
    	else
    	{
    		return Ok(item);
    	}
    }
