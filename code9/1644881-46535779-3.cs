    [HttpPost]
    public ActionResult TestCheckboxlist(ParentVM model)
    {
        ....
        List<string> selectedFruits = model.Fruits.Where(x => x.IsSelected);
    
    
    
