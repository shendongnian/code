    [System.Web.Http.HttpPost]
    public IHttpActionResult GetUserByID([FromBody]int id)
    {
        var user = userList.FirstOrDefault((p) => p.Id == id);
        if (user== null)
        {
            return NotFound();
        }
        return Ok(user);
    }
