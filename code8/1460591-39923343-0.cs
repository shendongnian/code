    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromUri] int id, [FromBody]CustomerViewModel customer)
    {
        customer.Id = 0;
        //Implementation
    }
