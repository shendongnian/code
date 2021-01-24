    public IActionResult SendResponse()
    {
        Response.Headers.Add("X-Total-Count", "20");
        return Ok();
    }    
