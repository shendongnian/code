    public IActionResult Index(IOptions<ImagesDBSettings> settings)
    {
        ImagesDBService ss = new ImagesDBService(settings);
        return View();
    }
