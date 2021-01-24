    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Person person) {
        if(ModelState.IsValid) {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }
