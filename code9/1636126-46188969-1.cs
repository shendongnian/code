    public IActionResult GetSomeData()
    {
        if(!CheckAccessCondition())
            return Unauthorized();
        return Ok(somevalue);
    }
