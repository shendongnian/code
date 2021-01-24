    [HttpPost]
    public ActionResult Edit(CustomerEditViewModel model)
    {
        var customer = _customerRepo.GetCustomerById(model.Id);
        // Check the current user role.    
        If (!User.IsInRole("Admin"))
        {
           customer.FirstName = model.FirstName;
           customer.LastName = model.LastName;
        }
        else
        {
           Mapper.Map(model, customer);
        }
        _customerService.UpdateCustomer(customer);
        // return to Index view
    }
