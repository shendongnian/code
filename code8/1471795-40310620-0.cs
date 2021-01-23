    public async Task<IHttpActionResult> Get(string SomeKey)
    {
        if(ExistsInDB(SomeKey))
            return Ok(SomeRecordFromDB(SomeKey));
        
        return NotFound();
    }
