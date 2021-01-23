    SampleContext context=new SampleContext();
    public ActionResult Index()
    {
        CompanyProfile profile;
        if (Session["Profile"] == null)
        {
           Session["Profile"] = context.Profile.FirstOrDefault();
        }
        profile = (CompanyProfile)Session["Profile"];
        return View(new BaseModel { Profile = profile });
    }
