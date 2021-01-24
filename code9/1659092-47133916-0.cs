    [HttpPost]
    [Route("api/v1/AddItem")]      
    public IHttpActionResult AddItem([FromBody]Model model) {
        if(ModelStat.IsValid) {
            return Ok(model); //...just for testing
        }
        return BadRequest();
    }
