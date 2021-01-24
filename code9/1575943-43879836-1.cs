    using (var dbContext = new Entities())
    {
        var numberOfCars = dbContext.Cars.Count(c => c.OwnerId == OwnderId);
        lblTotalCars.Text = numberOfCars.ToString();
    }
