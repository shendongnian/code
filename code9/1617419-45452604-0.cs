    [HttpPost("test/{id}")]
    public IActionResult Teste(int id)
    {
        if (id == default(int))
            return BadRequest();
        ...
    }
