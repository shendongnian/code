    public GigsController(GigsViewModel gigsViewModel)
    {
        _gigsViewModel = gigsViewModel;
    }
    // GET: Gigs
    public ActionResult Index()
    {
        _gigsViewModel.Get();
        return View(_gigsViewModel);
    }
