    public async Task<IHttpActionResult> PostOrder(Order order)
    {
        ....
        var response = new { Id = Guid.NewGuid() };
        return Ok(response);
    }
