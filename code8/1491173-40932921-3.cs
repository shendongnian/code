    [HttpPost]
    public ActionResult SortDesc (myViewModel model)
    {
		
		if(!ModelState.IsValid)
		{
			return View(list)
		}
		else
		{
			NumberSetList list = new NumberSetList();
            List<int> numbers = new List<int>();
            numbers.Add(model.Number1);
            numbers.Add(model.Number2));
            numbers.Add(model.Number3));
            numbers.Add(model.Number4));
            numbers.OrderByDescending(i => i);
            list.SortOrder = "Desc";
            return View(list);
		}
            
    }
