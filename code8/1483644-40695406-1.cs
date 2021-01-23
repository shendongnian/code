     public ActionResult Index(HomeViewModel model)
        {
            var results = mainDbContext.GetSomeResult(model.CodedropdownText.ToString(), model.Prop2, model.Prop3);         
          return View(results);
        }
