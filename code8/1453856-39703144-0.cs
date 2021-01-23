    [HttpPost]
    public ActionResult Index(UnauthenticatedEnquiryViewModel unauthenticatedEnquiryViewModel)
    {
        //unauthenticatedEnquiryViewModel.EnquiryType;
        //NEED TO ADD A METHOD THAT SENDS FILE TO CRM HERE
        if (ModelState.IsValid)
        {
            ...
    
            return View("Unauthsuccess", unauthenticatedEnquiryViewModel);
        }
    
        unauthenticatedEnquiryViewModel.Professions = DataAccessEnquiry.GetProfessionUnauthenticated();
        unauthenticatedEnquiryViewModel.EnquiryTypes = new List<EnquiryType>();
        //THIS path doesn't return value.
        //HERE return somethig
    }
