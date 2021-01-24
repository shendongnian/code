	[Route("getcustomer")]
	[HttpGet]
	public IHttpActionResult GetCustomer(int customerId)
	{    // as a test: only customer 1 exists
		if (customerId == 1)
		{
			return Ok(new Customer()
			{
				Id = customerId,
				Name = "John Doe",
			});
		}
		    
		// TODO: make sure 404 Err not found returned.
		return NotFound();
	}
