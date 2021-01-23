    var factory = new SummaryFactory();
    var carSummary = factory.Create<CarSummary>();
    var carSummary2 = factory.Create<CarSummary>(car => { car.TotalMiles = 50; });
    var carSummary3 = factory.Create<CarSummary>(new { TotalMiles = 50 });
    var employeeSummary = factory.Create(typeof(EmployeeSummary));
