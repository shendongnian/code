    [HttpGet("foo")]
    public IActionResult Foo() 
    {
        return Ok(new { Hello = "Hi", OneMoreField = 1234});
    }
