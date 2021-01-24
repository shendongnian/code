    IList<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem()
                {
                   Value = "Email",
                   Text = "Email"
                });            
    ViewBag.DropDownList = new SelectList(p.EmailList, "Value", "Text");
