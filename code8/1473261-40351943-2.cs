    Customer customer = db.Customers.SingleOrDefault(c => c.CustId == id);
    if (customer == null)
    {
        return NotFound();
    }
    // Get all devices
    var deviceList = db.Devices.ToList();
    // Get the selected device ID's for the customer
    IEnumerable<int> selectedDevices = db.CustomerDevices
        .Where(x => x.CustId == id).Select(x => x.DevId);
    // Build view model
    var model = new CustomerDeviceFormViewModel()
    {
        CustId = customer.CustId,
        CustDisplayName = customer.CustDisplayName,
        Devices = deviceList.Select(x => new CheckBoxListItem()
        {
            ID = x.DevId,
            Display = x.DevType,
            IsChecked = selectedDevices.Contains(x.DevId)
        }).ToList()
    };
    return View(model);
    
    
