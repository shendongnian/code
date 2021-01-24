    [HttpDelete]
    public IHttpActionResult Delete([FromODataUri] int key)
    {
        var found = _db.Set<T>().FirstOrDefault(e => e.Id == key);
        if(found != null)
        {
            _db.Set<T>().Remove(found);
            _db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
        else
        {
            return NotFound();
        }
    }
