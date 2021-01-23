    [ResponseType(typeof(UserModel))]
    [HttpGet]
    [Route("api/getusers/{id}")]
    public IHttpActionResult GetUser(Guid id)
    {
        var item = repository.Get(id);
        if (item == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        else
        {
            return Ok(item);
        }
    }
    like others
    [Route("api/getcities/{id}")]
