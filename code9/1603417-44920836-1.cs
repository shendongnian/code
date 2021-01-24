    public class MyController : Controller
        {
            // GET: My
            public ActionResult MyAction()
            {
                // shows your form when you load the page
                return View();
            }
    
            [HttpPost]
            public ActionResult MyAction(SomeModel model)
            {
                
                var selectedBookingDetails = model.bookingDetails;// this will be the selected dropdown item text.
            
                return View(model);
            }
        }
