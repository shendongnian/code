    public IHttpActionResult GetDict(string name)
    {
        try
        {
            switch(name) {
                case "simpleDict":
                   return Ok(_dataLayer.GetSimpleDict());
                case "extDict":
                   return Ok(_dataLayer.GetExtDict());
            }
    
            SomeLogger.SomeLogging(name, outDict);
            return Ok(new List<Item>());
        } 
        catch (Exception ex) 
        {
            // Just returning error
            return BadRequest(ex.Message);
        }
    }
