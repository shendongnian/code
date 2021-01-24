    [HttpGet]
    [Produces("application/json")]
    public IActionResult Get(string name)
    {
        var jsonStr = service.GetJsonStringFromDB();
    
        return Content(jsonStr);
        // Alternatively, pass the type here 
        //return Content(jsonStr, "application/json");
    }
