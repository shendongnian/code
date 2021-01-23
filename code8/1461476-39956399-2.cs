    [HttpPost]
    public ActionResult SampleSearch(string searchstring)
    {
        IEnumerable<ClassFile> listsearchData = ...
        return PartialView("_SampleSearch", listsearchData );            
    }
    
