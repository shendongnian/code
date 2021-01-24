    public IActionResult Get(int productId)
    {
      try
	  {
		Product product = _service.GetProduct(productId, currentUserRole);
		return Ok(product);
	  }
	  catch (AuthorizationException ex)
	  {
		return NotAuthorized(ex);
	  }
    }
