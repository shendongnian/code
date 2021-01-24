    [SwaggerResponse(HttpStatusCode.OK, "UserDTO", typeof(UserDTO))]
    public async Task<IHttpActionResult> Get([FromODataUri] int key)
    {
        var result = await UserRepo.GetAsync(key);
        ...
        return Ok(result);
    }
