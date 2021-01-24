    [HttpPost]
    public IHttpActionResult Post(PMSCost menu)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (menu.Price != 0)
                     return Ok(1);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }
        return BadRequest(ModelState);
    }
