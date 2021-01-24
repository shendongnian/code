    public IHttpActionResult GetSuccess()
    {
        var success = new SuccessDTO 
    	{ 
    		success = 1, 
    		message = "Ok", 
    		data = new List<RoleDTO>()
    		{ 
    			new RoleDTO 
    			{ 
    				roles_name = "Admin", 
    				description = "admin" 
    			}, 
    			new RoleDTO 
    			{ 
    				roles_name = "Administrator", 
    				description = "Administrator" 
    			} 
    		} 
    	};
        return Ok(success);
    }
    public IHttpActionResult GetError()
    {
        var error = new ErrorDTO 
    	{ 
    		success = 0, 
    		error = new ErrorCodeDTO 
    				{
    					code = 0,
    					message = "invalid username and password"
    				}
    	};
        return BadRequest(error);
    }
