    IEnumerable<int> selectedDevices = vmEdit.Devices.Where(x => x.IsChecked).Select(x => x.Id);
    // Remove existing devices for the customer
    // Note following is for EF6
    db.CustomerDevices.RemoveRange(db.CustomerDevices.Where(x => x.CustId  == vmEdit.CustId));
    // Add new selections
    foreach(int deviceId in selectedDevices)
    {
        CustomerDevice customerDevice = new CustomerDevice
        {
            CustId = vmEdit.CustId,
            DevId = deviceId
        };
        db.Add(customerDevice);
    }
    // Save and redirect
    db.SaveChanges();
    return RedirectToAction("Index");
    
    
