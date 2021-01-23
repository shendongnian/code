    public ActionResult New()
    {
      var _list = _context.Ingredients.ToList();
      var viewModel = new FoodViewMode 
      {
        Ingredients = _list
      };
      return View(viewModel);
    }
