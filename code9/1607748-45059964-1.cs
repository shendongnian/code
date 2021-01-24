    public class MyController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult GetMyTreeMapData(int someID, [DataSourceRequest] DataSourceRequest request)
        {
        	List<MyModel> items = new List<MyModel>();
        	items=SomeMethodToRecursivelyFillYourParentAndChildren();
        	return Json(items.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
