    [HttpPost]
    public IActionResult Post([FromBody]Order order)
    {
        if (!ModelState.IsValid)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
                            
        // Do stuff...
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
