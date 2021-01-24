    public async Task<IActionResult> Post([FromBody]Models.User user)
    {
        if(!ModelState.IsValid) 
        {
            if(user==null)
            {
                // user is null, which means we couldn't deserialize it or 
                // no data was sent with the request
                return BadRequest(new { Error = "Invalid formatted data." });
            }
            // return errors, since we know user is not null
            return BadRequest(ModelState);
        }
    }
