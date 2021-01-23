	[HttpGet]
	public ActionResult ActionMethodName(DataClass dataObj)
	{
		Sessions.ChangeLanguage(Session["Language"].ToString());
	}
	
