    [HttpGet]
    public ActionResult Index()
    {
        List<ListStatus> lstStatus = new List<ListStatus>(){
            new ListStatus() { Name="X",StatusID = Guid.NewGuid() },
        	new ListStatus() { Name="Y",StatusID = Guid.NewGuid() },
        	new ListStatus() { Name="Z",StatusID = Guid.NewGuid() }
        };
        			
        ViewModel objModel = new ViewModel();
        objModel.Statuses  = lstStatus;
        objModel.SelectedStatus = lstStatus[1].StatusID; // Select whatever you want here to be default.
        			
        return View(objModel);
    }
