    public class TestController
    {
        private TestService service;
        public TestController(TestService service)
        {
            this.service = service;
        }
        public ActionResult One(int param1, string param2)
        {
            return this.ActionWithTryCatch(() => this.service.MethodOne(param1, param2), "ViwName1");
        }
        public ActionResult Two(Date param3, bool param4)
        {
            return this.ActionWithTryCatch(() => this.service.MethodTwo(param3, param4), "ViwName2");
        }
        public IActionResult ActionWithTryCatch(Action action, string viewName)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                LogException(e.Message);
                AddModelError(e.Message);
            }
    
            return View(viewName);
        }
    }
