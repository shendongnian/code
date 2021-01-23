    using (var unit = UnitOfWorkFactory.Create())
    {
       IEntity<int> item =unit.CarsRepository.AddCar(new DomainCar ("Ferrari"));
       unit.Save(); //this will call internally to context.SaveChanges()
       int newId= item.Id; //you can extract the recently generated Id
    }
