    var CList = new List<SelectListItem>();
    
    StreetFooder sf = db.StreetFooders.Single(s => s.User.UserName == this.User.Identity.Name);
    
    var Cqry = from d in db.Categories
    where !d.IsDeleted && d.StreetFooder.Id == sf.Id
    orderby d.Name
    select d;
    
    CList.AddRange(Cqry.Distinct().Select(x => new SelectListItem 
    {
        Value = x.Id.ToString(),
        Text = d.Name
    }));
    ViewBag.CategoryList = new SelectList(CList);
