    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index(string lang = "en")
        {
            IndexViewModel indexViewModel;
            if (HttpContext.Cache["IndexViewModel"]!=null) 
            {
                indexViewModel = HttpContext.Cache["IndexViewModel"];
            }
            else 
            {
                // get your index view model from database by calling some service or repository
                indexViewModel = DatabaseService.GetIndexViewModelFromDatabase();
                // once we got the view model from a database we store it to cache and set it up so that it gets expired in 1 minute
                HttpContext.Cache.Insert("IndexViewModel", indexViewModel, null, DateTime.UtcNow.AddMinutes(1), Cache.NoSlidingExpiration);
            }
            indexViewModel.SelectedLanguage = lang;
            return View(indexModel);
        }
       
       [HttpPost]
       [Authorize(Roles="Backoffice")]
       public ActionResult ResetCache(string cacheKey)
       {
           if (HttpContext.Cache[cacheKey] != null)
               HttpContext.Cache.Remove(cacheKey);
       }
       //more actions..
    }
 
