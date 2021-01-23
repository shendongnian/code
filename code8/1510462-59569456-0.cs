    [HttpPost]
    [Route("some-endpoint/{someValue}")]
    public IActionResult UpdateTaskItemValue(int someValue, string someQueryString)
    	{
    		Debug.WriteLine(someValue);
            Debug.WriteLine(someQueryString);
    		return Ok();
    	}
