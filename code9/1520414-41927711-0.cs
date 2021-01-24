    public IHttpActionResult  POST([FromBody] CustomerVM customer)
     {
       if (!ModelState.IsValid) {
    		return BadRequest(ModelState);
    	}
         return Ok("success");
             
     }
