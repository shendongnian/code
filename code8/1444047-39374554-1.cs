    public ActionResult Index()
            {
                TestBaseViewModel model = new TestBaseViewModel();
                model.WindowType = (int)EnumsCollection.WindowTypes._blank;
                return View(model);
            }
