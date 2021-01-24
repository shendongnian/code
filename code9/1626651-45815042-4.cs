    [System.Web.Http.HttpGet]
    [Route("api/users/{id}")]
    public IHttpActionResult GetUserByID(int id)
    {
        var user = userList.FirstOrDefault((p) => p.Id == id);
        if (user== null)
        {
            return NotFound();
        }
        return Ok(user);
    }
