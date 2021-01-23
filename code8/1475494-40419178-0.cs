    public ActionResult TransferDevices(IList<XXXViewModel> viewModel)
    {
        var selected = viewModel.Where(x => x.isSelected)
                                .Select(x => x.Id)
                                .ToList();
        IQueryable<Device> devicesQueryable = _db.Devices;
    
        var devices = devicesQueryable.Where(x => selected.Contains(x.Id)).ToList();
    }
