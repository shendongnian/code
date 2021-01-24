	namespace MyProject
	{
		public class MyController : Controller
		{
			public ActionResult MyPage(int? Id)
			{
				var data = context.Report_Main.Find(Id); // Or whatever
				var vm = new MyViewModel(){
					Tracking = data.System_Tracking,
					// ... populate the viewmodel here from the data received
				};
				return View(vm); 
			}
		}
	}
