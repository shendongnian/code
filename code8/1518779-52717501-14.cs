    public IEntity<int> AddCar(DomainCar car)
    {
        var carDb=Mapper.Map<DbCar>(car);//automapper from DomainCar to Car (EF model class)
        var insertedItem=context.CARS.Add(carDb);
        return new Entity<int>(insertedItem,nameof(carDb.Id));
    }
