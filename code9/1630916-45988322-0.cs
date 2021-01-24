    public ActionResult Index()
    {
        var test = new TestClass()
        {
            TimeTest = DateTime.Now
        };
        ViewBag.TimeTest = test.TimeTest;
        return View();
    }
    public class TestClass
    {
        public DateTime TimeTest { get; set; }
    }
