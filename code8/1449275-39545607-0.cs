    public async Task<IActionResult> Index()
	{
	    var userId = _userManager.GetUserId(User);
		ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
		if (currentUser.PropBool)
			return View(currentUser);
		return View();
	}
