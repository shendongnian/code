    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        if (id == 0) return BadRequest();
        // ...
        return Ok(model);
    }
