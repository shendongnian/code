    var oList = db.Roles.Select(x => new SendGroupEmailViewModel
                   {
                       Roles = x.Roles.Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
    
        ViewData.myList = new SelectList(oList,
        
                   }, 
                        "Value", "Text", 15); // 15 = selected item or you can omit this value
 
