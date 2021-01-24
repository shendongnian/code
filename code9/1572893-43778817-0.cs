    public IHttpActionResult Post(int id)
    {
            string result = string.Empty;
            try
            {
              //some code
              return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error message");
            }
     }
