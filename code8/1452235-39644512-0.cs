    var customervm = new CustomerFormViewModel();
    {
       // Your existing code to map the entity property values goes here
    } 
    //Load all the states
    var states = _context.States.ToList();
    customervm.States = states;
    //Set the selected state
    customervm.StId = customer.StId;
    return View();
    
