     [HttpPut]
     [Route("v2/myaction/somethingelse/{message}")]
     public async Task<IHttpActionResult> MyAction(string message)
     {
         return Ok("Put ok");
     }
