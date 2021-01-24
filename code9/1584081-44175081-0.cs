        [Route("api/datasync/get")]
		[HttpGet]
		public IHttpActionResult GetOne()
		{
			return Ok(1);
		}
		[Route("api/datasync/get")]
		[HttpPost]
		public IHttpActionResult GetOnes()
		{
			return Ok(1);
		}
