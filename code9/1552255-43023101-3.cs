    [System.Web.Http.HttpPost]
    public IHttpActionResult AddSalesman([FromBody] Salesman sm)
    {
        //Do Stuff
        if (stuffNotOk)
        {
            return NotFound();
        }
        return Ok(product); 
    }
