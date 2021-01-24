    using (var dbContext = new Entities())
    {
        var numberOfCars = dbContext.Cars.Where(c => c.OwnerId == OwnderId).Count();
        lblTotalCars.Text = numberOfCars.ToString();
    }
