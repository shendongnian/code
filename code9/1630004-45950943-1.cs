    public IHttpActionResult Get(string category)
    {
        try
        {
            // code...
            return Ok(articlesByCategory);
        }
        catch (Exception ex)
        {
            // Something went wrong on our side (NOT the client's fault). So we need to:
            // 1. Log the error so we can troubleshoot it later
            // 2. Let the client know it is not their fault but our fault.
            return InternalServerError();
        }
    }
