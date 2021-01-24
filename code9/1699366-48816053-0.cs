      public ActionResult Index(string searchString)
        {
            ViewBag.CategoryID = new SelectList(_categoryRepo.getCategories(), "ID", "Name");
     
            // ViewModel
     
            var items = _stockRepo.getStock().Select(r => r.toStockVM());
     
            // Search
     
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToUpper();
                items = items.Where(r => 
                          r.Title.ToUpper().Contains(searchString));
            }
     
            if (!String.IsNullOrEmpty(Request["CategoryID"]))
            {
                var strDDLValue = Convert.ToInt32(Request["CategoryID"]);
     
                if (strDDLValue >= 1)
                {
                    searchString = searchString.ToUpper();
                    items = items.Where(r => r.SubCateogory.CategoryID == strDDLValue && r.Title.ToUpper().Contains(searchString));
                }
            }
     
            return View(items);
        }
