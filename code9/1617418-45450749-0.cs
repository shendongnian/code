    [HttpPost("test")]
    public IActionResult Teste(int id=0)
    {
        if (id==0)
            return BadRequest();
    
        ...
    }
