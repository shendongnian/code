    public ViewResult datastream(string dataID)
    {
        return view(this.GetDataViewModel(dataID));
    }
    
    public PartialViewResult datastreampartial(string dataID)
    {
        return PartialView("_datapartial", this.GetDataViewModel(dataID))
    }
    
    private DataViewModel GetDataViewModel(string dataId)
    {
        var data = db.data.FirstOrDefault(i => i.ID == dataID);
        var viewModel = new DataViewModel()
        {
            Data = data?.Data;
        }
        return viewModel;
    }
