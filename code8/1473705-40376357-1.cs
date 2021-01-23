    public ActionResult Edit(CustomerDeviceFormViewModel vmEdit)
    {
        if (ModelState.IsValid)
        {
            Customer customer = db.Customers
                       .Include(c => c.CustomerDevices)
                       .SingleOrDefault(c => c.CustId == id);
            if (customer == null)
            {
                return NotFound();
            }
            IEnumerable<int> selectedDevices = vmEdit.Devices.Where(x => x.IsChecked).Select(x => x.ID);
            // Remove all selected devices for this customer
            customer.CustomerDevices.Clear();
            // Add the new selected devices
            foreach (int deviceId in selectedDevices)
            {
                CustomerDevice customerDevice = new CustomerDevice
                {
                    CustId = customer.Id,
                    DevId = deviceId
                };
                customer.CustomerDevices.Add(customerDevice);
            }
            
            // Update the customer
            db.Customers.Update(customer); //or just db.Update(customer); same thing
            // Save and redirect
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(vmEdit);
    }
