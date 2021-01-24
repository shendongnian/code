    [HttpPost]
    public ActionResult Index(ViewModel viewModel)
    {
    
        /*
         * Code
         */
        int id = viewModel.id;
        CustomerInfo info = viewModel.info;
        Return View();
    }
