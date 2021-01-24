    public IActionResult Index()
        {
            SelectModel model = new SelectModel();
            //initialization of the list Before usage
            model.Scripts = new List<String>();
            model.Scripts.Add("Germany");
    
            return View(model);
        }
