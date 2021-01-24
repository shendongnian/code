    public ActionResult Index()
    {
        List<MyClass> ofitems = _repository.GetMyClasses(); // contains db access logic
        var byNodeId = ofitems.ToDictionary(x => x.ID, x => x);
        foreach (var node in ofitems)
        {
            // add current node to its parent's Children
            byNodeId[node.ParentID].Children.Add(node); 
        }
        ViewBag.ListText = TreeFormatter.Format(ofitems); 
        return View();
    }
        
