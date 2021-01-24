    [HttpPost]
    [ActionName("ProductEdit")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditProductAsync( [Bind(Include = "Id, Name, Flags, Organisations")] Item model)
    {
        model.Organisations = _uow.Products.GetOrganisations();
        model.Flags = _uow.Products.GetFlags();
    
        if (ModelState.IsValid)
        {
            await DocDBRepo<Item>.UpdateItemAsync(model.Id, model);
    
            return RedirectToAction("Index");
        }
    
        return View(model);
    }
