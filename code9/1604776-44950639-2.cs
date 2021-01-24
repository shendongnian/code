        [HttpGet]
        public ActionResult Language()
        {
            List<Language> activeL = LanguageController.GetAll();
            ViewBag.Languagess = activeLanguages;
            return View();
        }
       [HttpPost]
        public ActionResult Language(SettingsModel settings)
        {
            Language selectedLanguage = LanguageController.GetAll().Where(l => l.Id == settings.LanguageId).SingleOrDefault();
            //...   your post operations.
           
        }
