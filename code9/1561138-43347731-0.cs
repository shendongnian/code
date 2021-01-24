    [ResponseType(typeof(void))]
    public IHttpActionResult updateCarInfo([FromBody] carClass cars)
    {
    	if (!ModelState.IsValid)
    	{
    		return BadRequest(ModelState);
    	}
    
    	db.Entry(cars).State = EntityState.Modified;
    
    	db.SaveChanges();
    
    	return StatusCode(HttpStatusCode.NoContent);
    }
