    [Route("/api/addsalesman")]
    [HttpPost]
    public IActionResult AddSalesman([FromBody] Salesman salesman)
    {
        //Do Stuff
        if (stuffNotOk)
        {
            return NotFound();
        }
        return Ok(product); 
    }
