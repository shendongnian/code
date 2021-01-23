    public class TestController : Controller
    {
        [OutputCache(Location = OutputCacheLocation.None)]
        public JsonResult TestJson(TestClass tc)
        {
            return Json(new { result = "foo=" + tc.foo + " bar=" + tc.bar }, JsonRequestBehavior.AllowGet);
        }
        public class TestClass
        {
            public int foo { get; set; }
            public string bar { get; set; }
        }
    }
