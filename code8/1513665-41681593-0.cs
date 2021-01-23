    List<SelectListItem> items= new List<SelectListItem>();
    db.ShirtQuantities.Each(a=>{
        items.Add(new SelectListItem{
            Text=a.Id,
            Value=a.Name
        });
    
    }
    
    ViewBag.ShirtQuantityId = items
