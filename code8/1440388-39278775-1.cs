    Database.SetInitializer(new EmployeeDatabaseInitialiser());
    new EmployeeContext().Database.Initialize(true);
    
    var context = new EmployeeContext();
    var bank1 = new EmployeeBank{Name = "Bank1"};
    var bank2 = new EmployeeBank {Name = "Bank2"};
    var epm1 = new EmployeePaymentMethod();
    var epm2 = new EmployeePaymentMethod();
    
    context.EmployeeBanks.Add(bank1);
    context.EmployeeBanks.Add(bank2);
    context.EmployeePaymentMethods.Add(epm1);
    context.EmployeePaymentMethods.Add(epm2);
    context.SaveChanges();
    
    bank1.EmployeePaymentMethod = epm1;
    epm2.EmployeeBank = bank2;
    context.SaveChanges();
