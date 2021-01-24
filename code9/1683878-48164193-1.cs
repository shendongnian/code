    [HttpGet("{stringName}")]
    public Task<IActionResult> MethodName(string stringName)
    {
    	var object = JsonConvert.Deserialize<ObjectModel>(stringName);
    }
