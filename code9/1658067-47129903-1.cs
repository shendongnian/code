    [PrivateCacheControlResultFilter]
    [HttpGet("universities")]
    public IActionResult GetAllUniversities(string location)
    {
        if (/*location not found*/)
          return BadRequest();
 
        ...
        return Ok(universities);
    }
