    public void ActionResult()
    {
        
         List<RootObject> list = repo.GetList(); // i assumed that you get list 
         //from repo
        ViewBag.modelList = JsonConverter.Convert(list);
        return View()
    }
