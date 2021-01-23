    public async Task<IActionResult> Get(string id)
    {
        if (id== null)
        {
            return BadRequest("id is not provided.");
        }
        // other code, including:
        // return Ok(some data);
    }
