	public class AnalysisController : Controller
	{
		public ActionResult Index() {
			List<Order_Detail> result = new List<Order_Detail>();
			//The code below will never return anything because you are peforming operations on an empty list
			result.GroupBy(l => l.ProductName).Select(cl => new Order_Detail
			{
				 ProductName = cl.First().ProductName,
				 Quantity = cl.Sum(c => c.Quantity)
			}).OrderByDescending(k=>k.Quantity).ToList();
			var model = new ProductPopModel {
				Result = result
			};
			
			return View(model);
		}
	}
