    public IHttpActionResult GetInclusionWorkBooks()
    {
        string query = this.Url.Request.RequestUri.Query;
        if (string.IsNullOrEmpty(query))
        {
            return BadRequest();
        }
        return Ok(db.GetInclusionWorkBookData());
    }
