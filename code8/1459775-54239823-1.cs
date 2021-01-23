        [HttpGet]
		[EnableQueryForGuid]
		[ODataRoute("GetSomething")]
		public IHttpActionResult GetSomething()
        {
          ....
        }
