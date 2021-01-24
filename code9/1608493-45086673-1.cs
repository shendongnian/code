    [HttpPost]
    [Route("test1")]
    [AllowAnonymous]
    public IActionResult Test([FromBody] Class1 data)
    {
        return Ok();
    }
