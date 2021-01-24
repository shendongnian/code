    [HttpPost]
    public ActionResult Index(DropDownViewModel viewModel)
    {
       var id = viewModel.SelectedSongId;
       ...
    }
