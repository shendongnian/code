    var customers = context.Customers.ToList(); // Make to add some Where clause here and avoid loading all data from Customer table :D
    foreach(var customer in customers)
    {
        context.Entry(customer)
               .Collection(p => p.CustomersPics)
               .Query()
               .Where(p => p.IsDeleted == true)
               .Load();
    }
