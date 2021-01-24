    public class SomeController : Controller
    {
        //
        // GET: /Products/
        [HttpPost]
        public ActionResult PostbackAction(FormCollection form)
        {
           // Add action logic here
           string scannedValue =  form["txtScannedValue"];
           //string scannedValue =  form["hdnScannedValue"];
           if( scannedValue == "1" ) {
              return View("View1");
            } else if (scannedValue== "2") {
              return View("View2");
          }
      }
    }
