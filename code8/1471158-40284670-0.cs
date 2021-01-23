     public ActionResult SelectCategory() {
    
             var viewModel = new ViewModel();
        
             List<SelectListItem> items = new List<SelectListItem>();
        
             items.Add(new SelectListItem { Text = "A", Value = "A"});
        
             items.Add(new SelectListItem { Text = "B", Value = "B" });
        
             // SelectListItem has a boolean property Selected, which is false by default 
             items.Add(new SelectListItem { Text = "C", Value = "C", Selected = true });
        
             viewModel.CategoryType = items;
        
             return View();
        
         }
