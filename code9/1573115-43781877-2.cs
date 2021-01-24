    // No extra thread is called and the request thread is only 
    // used in between "await" calls
    public async Task<IActionResult> Get(string name = _defaultName)
    {
        var result = await GetResultFromDatabase();
        return Ok(someModel);
    }
