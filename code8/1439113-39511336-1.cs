    [HttpGet]
 	[ODataRoute("Meetings({key})/Badges")]
 	public IHttpActionResult GetBadges(ODataActionParameters parameters)
 	{
 		return Ok();
 	}
