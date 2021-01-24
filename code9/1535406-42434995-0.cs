    public IHttpActionResult Get(string fields="all")
    {
        try
        {
            var results = _tripRepository.Get();
            if (results == null)
                return NotFound();
            // Getting the fields is an expensive operation, so the default is all,
            // in which case we will just return the results
            if (!string.Equals(fields, "all", StringComparison.OrdinalIgnoreCase))
            {
                var shapedResults = results.Select(x => GetShapedObject(x, fields));
                return Ok(shapedResults);
            }
            return Ok(results);
        }
        catch (Exception)
        {
            return InternalServerError();
        }
    }
