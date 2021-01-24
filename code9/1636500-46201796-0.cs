	public class FooController : Controller
	{
		[HttpGet]
		public void Create()
		{
			return this.View("~/Views/FooController/Create.cshtml", new MyModel() );
		}
		[HttpGet]
		public void Create(MyModel model)
		{
			//Do something with model information, such as save to database
		}
	}
