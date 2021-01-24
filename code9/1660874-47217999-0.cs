    // GET: api/Cities/5
    [HttpGet("{id}", Name = "GetCity")]
    public IActionResult Get(Guid id)
    {
    	City city = _cityRepository.Get(id);
    	if (city == null)
    	{
    		return NotFound();
    	}
    
    	CityData cityData = new CityData
    	{
    		Name = city.Name,
    		...
    	};
    	
    	return Json(cityData);
    }
