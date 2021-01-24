    public enum Color
    {
    	None,
    	Green,
    	Red,
    }
    [Route("getSomething")]
    [HttpGet]
    public string Get(Color color)
    {
    	// ...
    }
