    public ActionResult YourControllerAction() {
        
        // stuff
        this.ViewData["items"] = commodities
            .GetAll()
            .Select( c => new SelectListItem() { Text = c.Code, Value = c.Oid.ToString() } )
            .ToList();
        // stuff
        return this.View( viewModel );
    }
