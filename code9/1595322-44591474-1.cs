    [HttpGet]
    public IActionResult ValidateName([FromQuery] string username)
    {
         if(/* some validation here */)
         {
              return Ok( "Valid" );
         }
         else
         {
              return NotFound( "Incorrect" );
         }
    }
