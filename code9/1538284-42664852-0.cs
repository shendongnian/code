    Public ActionResult Index(string show)
    {
        if (User.Identity.IsAuthenticated && String.IsNullOrEmpty(show))
        {
            Return RedirectToAction("Dashboard","Manage");
        }
        else
        {
            Return View();
        }
    }
    
