    [HttpGet]
    [Route("api/owners/{id}", Name = "GetOwnerById")]
    public IHttpActionResult GetOwner(int id)
    {
    	//	Obtain the owner by id here
    	return Ok(new ApiResponse());
    }
    
    [HttpPost]
    [Route("api/owners/{productCode}"/*, Name = "CreateOwner"*/)]
    public IHttpActionResult PostOwner(string productCode, Owner owner)
    {
    	return CreatedAtRoute("GetOwnerById", new { id = owner.Id }, owner);
    }
