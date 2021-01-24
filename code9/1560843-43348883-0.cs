    // PUT: api/Engineers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEngineer([FromRoute] int id, [FromBody] Engineer engineer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    	
    	// Retrieve engineer by id
    	var entity = await _dbContext.Engineers
    		.Include(p => p.EngineerApplications)
    		.FirstOrDefault(item => item.EngineerId == id);
    
        if (entity == null)
        {
            return NotFound();
        }
    	
    	// Set changes (exclude entity's key)
    	entity.FirstName = engineer.FirstName;
        entity.MiddleName = engineer.MiddleName;
    	entity.LastName = engineer.LastName;
    	
    	// There another ways to check engineer applications,
		//in this case we want to update not add
    	// So we don't worry about to check if child if exists or not
    	if (engineer.EngineerApplications.Count == entity.EngineerApplications.Count)
    	{
    		// Apply changes in navigation properties
    		for (var i = 0; i < entity.EngineerApplications.Count; i++)
    		{
    			// Set changes, assuming those values are in engineer instance
    			entity.EngineerApplications[i].Active = engineer.EngineerApplications[i].Active;
    		}
    	}
    
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
    		// Add logging for exception
    		return new ObjectResult(entity) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    
        return Ok(entity);
    }
