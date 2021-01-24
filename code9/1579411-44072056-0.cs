    public async Task<IHttpActionResult> Get(int id)
    {
        var testObject = await _repository.GetAsync(id);
        return Ok(testObject);
    }
