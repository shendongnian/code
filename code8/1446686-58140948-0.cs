    [HttpGet("{guid}", Name = "GetDocument")]
    public IActionResult GetByGuid(string guid)
    {
        var doc = DocumentDataProvider.Find(guid);
        if (doc == null)
            return NotFound();
    
        return new ObjectResult(doc) {StatusCode = 200};
    }
