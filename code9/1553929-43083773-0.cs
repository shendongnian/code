    [HttpPost]
    public ActionResult Index(YourViewModel model)
    {
      if(ModelState.IsValid)
      {
           // to do :Save and Redirect ( PRG pattern)
      }
      // Let's reload the collection needed to render the dropdown
      var listItem = new List<SelectListItem>(){
        new SelectListItem { Text = "A", Value = "1" },
        new SelectListItem { Text = "B", Value = "2" }
      };
      ViewData["List"] = new SelectList(listItem, "Value", "Text", "");
      return View(model);
    }
