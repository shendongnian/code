    List<SelectListItem> categories = db.Categories.Select(x => new SelectListItem()
    {
        Value = x.Id.ToString(), // assumes Id is not already typeof string
        Text = x.Name
    }).ToList();
    categories.Insert(0, new SelectListItem(){ Value = "0", Text = "All" }) // Or .Add() to add as the last option
    ViewBag.Categories = categories;
