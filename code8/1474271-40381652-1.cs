       public class CustomerCOntroller(){
             public ActionResult Index(){
                  CustomerViewModel viewModel = new CustomerViewModel();
                  return View(viewModel);
             }       
      }
