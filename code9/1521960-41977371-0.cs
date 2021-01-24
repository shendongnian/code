    public ActionResult Index()
    {
        if (!S1.Server.IsBusy())
        {
            return new RedirectResult("http://S1.MainServer.com");
        }
        else if(!S2.Server.IsBusy())
        {
            return new RedirectResult("http://S2.MainServer.com");
        }
        else if (!S3.Server.IsBusy())
        {
            return new RedirectResult("http://S3.MainServer.com");
        }
        else return View();
    }
