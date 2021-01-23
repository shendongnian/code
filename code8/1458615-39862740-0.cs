    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(string lang = "en")
        {
            IndexViewModel indexViewModel;
            if (Cache["IndexViewModel"]!=null) 
            {
                indexViewModel = Cache["IndexViewModel"];
            }
            else 
            {
                indexViewModel = DatabaseService.GetIndexViewModelFromDatabase();
                Cache.Insert("IndexViewModel", indexViewModel, null, DateTime.UtcNow.AddMinutes(1), Cache.NoSlidingExpiration);
            }
            indexViewModel.SelectedLanguage = lang;
            return View(indexModel);
        }
       //more actions..
    }
 
