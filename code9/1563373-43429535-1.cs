    public ActionResult Inventory(SearchViewModel Search, int page = 1
    {
      var viewModel = _reportService.GetProducts(page, Search.Term, Search.Type);
      return View(viewModel);
    }
