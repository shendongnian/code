    [HttpPost]
    public virtual IActionResult Post(/* ... */)
    {
    	//	Create and save an instance in repository
    	//	var createdObject = ...;
    
    	return CreatedAtAction(nameof(Get), new
    	{
    		//	Put actual id here
    		id = 123
    	}, createdObject);
    }
