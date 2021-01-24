	public sealed class CompanyMustBeRegisteredAttribute : AuthorizeAttribute
	{
		public override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			// or filterContext.HttpContext.Request.RawUrl
			var returnUrl = filterContext.HttpContext.Request.Url.ToString();
			filterContext.Result =
				new RedirectToActionResult("Setup", "SetupController", new { returnUrl });
		}
	}
