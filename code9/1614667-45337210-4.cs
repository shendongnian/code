        public class HomeController : Controller
        {
    
            public class ValidForm
            {
                public string Id { get; set; }
                public int data1 { get; set; }
                public Data2 data2 { get; set; }
            }
    
            public class Data2
            {
                public int option1 { get; set; }
                public int option2 { get; set; }
            }
    
    
            public ActionResult Index()
            {
                var model = new ValidForm[2] { new ValidForm { }, new ValidForm {data2 = new Data2{}} };
                return PartialView(model);
            }
            [HttpPost]
            public ActionResult Tester(ValidForm model)
            {
                return View("Index", new ValidForm[1] { model });
            }
    }
