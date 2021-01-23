    var carEntityList= new List<CarEntity>(); //assume this has items
    var carList = new List<Car>();
    foreach(car carEntity in carEntityList)
    {
      var c= new Car();
      c.CarId =carEntity.Id;
      // to do : Map other property values as well.
      carList.Add(c);     
    }
