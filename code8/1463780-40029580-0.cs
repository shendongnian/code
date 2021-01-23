    [HttpPost("api/callToApi")]
    public IActionResult Post([FromBody] string name)
    {
        return Ok(_context.MyDBTable.Where(a => a.Name.Equals(name)));
    }
