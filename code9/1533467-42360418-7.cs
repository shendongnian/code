    // GET: api/authors/search?namelike=th
    [HttpGet("Search")]
    public IActionResult Search(string namelike)
    {
        var result = _authorRepository.GetByNameSubstring(namelike);
        if (!result.Any())
        {
            return NotFound(namelike);
        }
        return Ok(result);
    }
