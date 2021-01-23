    public IActionResult Create()
            {
                StaffViewModel model = new StaffViewModel();
                model.CityList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "İstanbul", Value = "1"},
                    new SelectListItem {Text = "Sivas", Value = "2"}
                };
    
                return View(model);
            }
