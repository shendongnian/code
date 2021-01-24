    public IHttpActionResult GetTest(int id1, int id2, int id3)
    {
        if (id1 != 1)
        {
            return NotFound();
        }
        return Ok("Values are correct");
    }
