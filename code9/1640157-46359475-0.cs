    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit( EnquiryVM enquiryVM)
    {
        if(!ModelState.IsValid)
        {
            ConfigureViewModel(enquiryVM);
            return View(enquiryVM)
        }
        // Get the data model
        var enquiry = db.Enquiries.FirstOrDefault(x => x.ID == enquiryVM.ID.Value);
        // update properties of enquiry from the enquiryVM
        enquiry.EnquiryNumber = enquiryVM.EnquiryNumber; 
        enquiry.ClosingDate = enquiryVM.ClosingDate; 
        ....
        foreach (var lineItemVm in enquiryVM.LineItems)
        {
            if (lineItemVm.ID.HasValue)
            {
                var lineItem = enquiry.LineItems.FirstOrDefault(x => x.ID == lineItemVm.ID.Value);
                // update properties of lineItem from lineItemVm (but dont add it to the collection)
                lineItem.ItemDesc = lineItemVm.ItemDesc;
                lineItem.Quantity = lineItemVm.Quantity;
                lineItem.ManufacturerID = lineItemVm.ManufacturerId;
            }
            else
            {
                // create a new EnquiryLineItem data model based on lineItemVm and add it to the data models `LineItems` collection
                EnquiryLineItem enquiryLineItem = new EnquiryLineItem();
                enquiryLineItem.EnquiryID = enquiryVM.ID.Value; // modify this
                enquiryLineItem.ItemDesc = lineItemVm.ItemDesc;
                enquiryLineItem.Quantity = lineItemVm.Quantity;
                enquiryLineItem.ManufacturerID = lineItemVm.ManufacturerId;
                enquiry.EnquiryLineItems.Add(enquiryLineItem);
            }
            db.Entry(enquiry).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
