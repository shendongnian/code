    public class HomeController : Controller
    {
    	[HttpGet]
    	public ActionResult Index()
    	{
    		return View(new SampleViewModel());
    	}
    
    	
    	public JsonResult ValidateBalieCode(string BalieCode)
    	{
    		string strUserName = string.Empty;
    		string strPassword = string.Empty;
    		
    		 List<SampleViewModel> _db = new List<SampleViewModel>();			
    		_db.Add(new SampleViewModel() { BalieCode = "1", UserName = "test1", Password = "test1" });
            _db.Add(new SampleViewModel() { BalieCode = "2", UserName = "Test2", Password = "test2" });
    		
    		
    		var SampleViewModel = _db.Find(x => x.BalieCode == BalieCode);
    		if(SampleViewModel != null)
    		{
    			strUserName = SampleViewModel.UserName;
    			strPassword = SampleViewModel.Password;
    		}
    		
    		return Json(new{ UserName = strUserName, Password = strPassword }, JsonRequestBehavior.AllowGet);
    	}
    }
