    public class ExampleController
    {
    
        [HttpGet]
        public ActionResult Customers(string nameParameter)
        {
            //Code
            return Json(nameParameter);
        }
    }
