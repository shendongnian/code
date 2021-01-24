    public class SomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {            
            ModelClass model = new ModelClass();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(ModelClass model)
        {
    		model.ReadData();
    		TempData['data'] = model.Data
    
    		return View(data);
        }
    
        [HttpPost]
        public FileContentResult DownloadCSV(ModelClass model)
        {
    		// model only has the date populated from the form, so take the data from TempData
    		model.Data = TempData['data']
			
			// ... generate CSV    	
        }
    }
	
