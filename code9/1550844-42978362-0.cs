    /// <summary>
    /// Returns some data based on <paramref name="someData"/> parameter.
    /// </summary>
    /// <param name="someData">Some data. (Must be exactly 5 characters wide)</param>
    /// <response code="200">Returns indexed tags on success</response>
    /// <response code="400">Invalid data sent</response>
    /// <returns>A paged list of results</returns>
    [HttpGet("{someData:MinLength(5):MaxLength(5)}")]
    [ProducesResponseType(typeof(MyReturnType), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetSomeData(string someData)
    {
    }
