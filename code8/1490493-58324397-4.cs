	public override async Task<IActionResult> SignUp()
	{
		...
		var emailBody = View("Emails/SignupNotification")
			.RenderToStringAsync(_serviceProvider);
		...
		return View();
	}
