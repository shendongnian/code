	public class Program
	{
		public static void Main()
		{
			var result = typeof(TestController).GetMethod("MyMethod").ReturnType;
			
			Console.WriteLine("TestController:MyMethod returns {0}", result.Name);
		}
		
		public class TestController
		{
			public ActionResult MyMethod()
			{
				return new ViewResult();
			}
		}
		
        // mocking System.Web.Mvc
		public abstract class ActionResult { }
		public class ViewResult : ActionResult { }
        public class JsonResult : ActionResult { }
	}
