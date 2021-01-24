    public ActionResult Index()
    {
    
      List <SelectListItem> vegList = new List<SelectListItem>
      {
      new SelectListItem {Text = "Cheese",Value="1" },
      new SelectListItem {Text = "Mushrooms",Value="2" },
      new SelectListItem {Text = "Tomatoes",Value="3" },
      new SelectListItem {Text = "Onions",Value="4" }
      };
    
      ViewBag.Vegetables = vegList;
    
        return View();
    }
    
    
    
    
    [HttpPost]
    public ActionResult AddVegetables(string[] VegetablesDDL)
    {
      var selectedVegetablesIDs = VegetablesDDL.ToList();
    
      foreach(var selected in selectedVegetablesIDs)
      {
        // use selected item
      }
    
          return View();
    }
