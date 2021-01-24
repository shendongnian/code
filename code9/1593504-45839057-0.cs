	[ViewComponent(Name = "Footer")]
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var model = new FooterModel();
			return View(model);
		}
	}
