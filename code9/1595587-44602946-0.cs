    [HttpGet] 
    public IHttpActionResult GetAllProductsById() 
    { 
        string headerValue = Request.Headers.GetValues("X-Hidden-List").FirstOrDefault(); 
        if (!string.IsNullOrEmpty(headerValue))
        {
            var results = DeserializeListAndFetch(headerValue); 
            return Ok(results); 
        }
        else
        {
            var results = ReturnEverything();
            return Ok(results);
            // or if you don't want to return everything: 
            // return BadRequest("Oops!");
        }
    }
