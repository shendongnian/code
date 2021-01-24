    IList<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem()
                {
                   Value = "Hello",
                    Text = "World"
                });        
    ViewBag.DropDownList = lst;
