    public IActionResult LoadVisit(int? id)
    {
    
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        try
        {
            return ViewComponent("ClientVisit", new { visitID = id.GetValueOrDefault() });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
