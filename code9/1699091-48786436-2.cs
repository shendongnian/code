    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var value = -2;
            var viewModel = new IndexViewModel();
            if(value < 0)
            {
                viewModel.CropY = 0;
            }
            else
            {
                viewModel.CropY = value;
            }
    
            return View(viewModel);
        }
    }
