		[HttpPost]
		[Authorize(Roles = "Role1,Role2,Role3")]
		public IActionResult Post() {
		  //...
		  string userName = this.User.Identity.Name;
		  //...
		}
