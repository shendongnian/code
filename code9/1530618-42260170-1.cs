    public ActionResult Index()
    {
        var webClient = new WebClient();
        var json = webClient.DownloadString(@"http://www.myurl.json");
        Books books = JsonConvert.DeserializeObject<Books>(json);
    
        return View(books);
    }
