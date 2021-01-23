    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CustomerDeviceFormViewModel vm)
    {
        if (ModelState.IsValid)
        {
            foreach (var deviceId in vm.Devices.Where(x => x.IsChecked).Select(x => x.ID))
            {
                var customerDevices = new CustomerDevice
                {
                    CustId = vm.CustId,
                    DevId = deviceId
                };
    
                db.CustomerDevices.Add(customerDevices);
            }
    
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(vm);
    }
