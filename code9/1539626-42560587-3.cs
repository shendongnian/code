    var customers = new Customer[]
    {
        new Customer{ID=201,FirstName="Joe",LastName="Gatto",Telephone="07580043213"},
        new Customer{ID=202,FirstName="Sal",LastName="Vulcano",Telephone="0758243454"},
        new Customer{ID=203,FirstName="James",LastName="Murray",Telephone="07580043290"}
    };
    
    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Customer ON")
    
    foreach (Customer s in customers)
    {
        context.Customers.Add(s);
    }
        
    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Customer OFF")
