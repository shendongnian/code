    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
       if(id==0)
          return BadRequest(new {Messagae = "Something is not correctT"});
       var result = await GetSomeMyModelObject();
       return result;
    }
