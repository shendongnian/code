    [HttpPost]
    [Route("quotes")]
    public IActionResult Quotes(Home model)
    {
      if(!ModelState.IsValid)
      {
        return View(model);
      }
      //continue your code to save
      return RedirectToAction("Index");
    }
