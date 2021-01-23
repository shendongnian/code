	public override async Task<IActionResult> SignUp()
	{
		...
		// send an email notification
		var emailView = View("Emails/SignupNotification"); // simply get the email view
		var emailBody = await RenderToStringAsync(emailView, _serviceProvider); // render it as a string
		SendEmail(emailBody);
		...
		return View();
	}
