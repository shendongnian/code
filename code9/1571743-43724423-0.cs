    public class TestAPIController : Controller
    {
        [HttpGet]
        public ActionResult Data()
        {
            return Json(new ArrayResult { Arr = new int[] { 1, 2, 3 } });
        }
    }
    public class ArrayResult
    {
        public int[] Arr { get; set; }
    }
