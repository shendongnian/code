    [Route("Edit/{id:int}")]
    [HttpGet]
    public ActionResult Edit(int id) {
        // do stuff
        return View(viewModel);
    }
    
    [Route("Edit/{id:int?}")]
    [HttpPost]
    public ActionResult Edit(DraftViewModel draft) {
        if (!ModelState.IsValid) return View(draft);
        // do stuff
        return RedirectToAction("Index");
    }
