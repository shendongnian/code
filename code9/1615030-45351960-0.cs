    public abstract class BaseController : Controller
    {
        protected IEnumerable<Data> QueryData(int? userId = null)
        {
            ...
        }
    }
    public class MainController : BaseController
    {
        public ActionResult GetData()
        {
            var data = QueryData();
            return View(data);
        }
    }
    public class OtherController : BaseController
    {
        public ActionResult GetMyData()
        {
            var userId = GetCurrentUserId();
            var data = QueryData(userId);
            return View(data);
        }
    }
