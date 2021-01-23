    [HttpGet]
		[AllowAnonymous]
		public ActionResult SearchSpots(string searchfilter)
		{
			return RedirectToAction("Index", new { filter = searchfilter}); 
		}
