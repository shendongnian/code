    public LanguageController : Controller
    {
        public ActionResult show( Language lang = null )
        {
            ViewBag.LanguageList = ListOfLanguages();
            return View( lang );
        }
    
        // i try something like that and dont working, 
        // that show list of language but razor form call controler method with empty parameter
        public static List<SelectListItem> ListOfLanguages()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach ( Language l in _languageRepository.Languages )
            {
                list.Add( new SelectListItem()
                {
                    Value = l.Index,
                    Selected = false,
                    Text = l.Name
                });
            }
            return list;
        }
    }
