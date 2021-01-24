     [ProducesResponseType(typeof(ApiBadRequestResponse), (int)HttpStatusCode.BadRequest)]
     public async Task<IActionResult> GetSomeData(string someData)
     {
       return BadRequest(new ApiBadRequestResponse(ModelState));
     }
