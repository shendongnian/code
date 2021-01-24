    [Route("DoThings")]
    public IActionResult DoThings(string filter1 = null, string filter2 = null)
    {
        return Ok("Test");
    }
