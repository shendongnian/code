    [HttpGet]
    public ActionResult EditProductAsync()
    {
        var model = new ProductViewModel()
        {
            Flags = _uow.Products.GetFlags(),
            Organisations = _uow.Products.GetOrganisations()
        };
        return View(model);
    }
