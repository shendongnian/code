    public class SomeController : Controller
    {
        [HttpPost]
        public ActionResult PostbackAction()
        {
            // Add action logic here
           string scannedValue =  Request.Form["txtScannedValue"].ToString();
           //string scannedValue =  form["hdnScannedValue"];
           if( scannedValue == "1" ) {
              return View("View1");
            } else if (scannedValue== "2") {
              return View("View2");
           }
        }
    }
