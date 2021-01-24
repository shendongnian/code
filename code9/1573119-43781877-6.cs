    // Here no async operations are called, so Task is not necessary
    public IActionResult Index(string name = _defaultName)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }
