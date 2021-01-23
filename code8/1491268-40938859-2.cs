		[HttpPost, Route("Logout")]
		public async Task<IActionResult> LogOut() {
		  await HttpContext.Authentication.SignOutAsync("MyCookie");
		  return Ok();
		}
