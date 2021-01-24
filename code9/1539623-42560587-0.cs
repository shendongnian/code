    var customers = new Customer[]
    {
        new Customer{FirstName="Joe",LastName="Gatto",Telephone="07580043213"},
        new Customer{FirstName="Sal",LastName="Vulcano",Telephone="0758243454"},
        new Customer{FirstName="James",LastName="Murray",Telephone="07580043290"}
    }
    foreach (Customer s in customers)
    {
        context.Customers.Add(s);
    }
    context.SaveChanges();
