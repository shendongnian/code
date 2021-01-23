    // GET api/things/5
    [HttpGet("{id}")]
    public async Task<Thing> GetAsync(int id)
    {
        Thing thingFromDB = await GetThingFromDBAsync();
        if(thingFromDB == null){
            throw new HttpResponseException(HttpStatusCode.NotFound); // This returns HTTP 404
        }
        // Process thingFromDB, blah blah blah
        return thing;
    }
