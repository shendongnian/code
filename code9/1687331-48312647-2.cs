    var model = new ViewModel();
    // cast to proper enum values with current hour & minute
    YogaTime hour = (YogaTime)((DateTime.Now.Hour * 100) + DateTime.Now.Minute);
    
    model.EnumSelectList = Enum.GetValues(typeof(YogaTime))
    		       .Cast<YogaTime>().Where(x => x >= hour)
    		       .Select(x => new SelectListItem() 
                   {
                        Value = ((int)x).ToString(),
                        Text = ((Enum)(object)x).GetDisplayName()
    		       }).ToList();
    return View(model);
