    [Route("api/v1/Product/{site}/{start?}/{pageSize?}/{from?}")]
    public IHttpActionResult Product(Site site, int start = 1, int pageSize = 100, long? fromLastUpdated = null)
    {
    	if (fromLastUpdated.HasValue)
        {
    		var ticks = fromLastUpdated.Value;
    		var time = new TimeSpan(fromLastUpdated);
    		var dateTime = new DateTime() + time;
    		// ...
    	}
    	return ...
    }
