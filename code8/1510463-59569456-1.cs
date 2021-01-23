    [HttpPost]
    [Route("some-endpoint/{someValue}")]
    public IActionResult SomeEndpointMethod(int someValue, string someQueryString)
    	{
    		Debug.WriteLine(someValue);
            Debug.WriteLine(someQueryString);
    		return Ok();
    	}
