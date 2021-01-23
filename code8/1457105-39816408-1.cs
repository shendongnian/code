	public SomeController : Controller
	{
		[SystemAdminFilter]		// at Action level
		public ActionResult SomeAction()
		{
				// perform your actions
		}
