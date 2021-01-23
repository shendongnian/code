    public class TestController
    {
        private TestService service;
        public TestController(TestService service)
        {
            this.service = service;
        }
        public ActionResult One(int param1, string param2)
        {
            this.service.MethodOne(param1, param2);
            return View("ViwName1");
        }
        public ActionResult Two(Date param3, bool param4)
        {
            this.service.MethodTwo(param3, param4);
            return View("ViwName2");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            LogException(filterContext.Exception.Message);
            AddModelError(filterContext.Exception.Message);
            
            var errorView = new ViewResult { ViewName = "~/Path/To/Error/View" };
            filterContext.Result = errorView;
        }
    }
