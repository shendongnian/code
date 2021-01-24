       [System.Web.Mvc.HttpGet]
    public ViewResult AddMedia()
    {
        URL newUrl1 = new URL();
        var model = new Media();
        model.MediaRSSURL = new List<URL>();
        model.MediaRSSURL.Add(newUrl1);
    
        return View(model);
    }
