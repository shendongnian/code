    public ViewResult datastream(string dataID)
    {
        return view(GetData(dataID));
    }
    
    public PartialViewResult datastreampartial(string dataID)
    {
        return PartialView("_datapartial", GetData(dataID));
    }
