    var carEntityList= new List<CarEntity>(); //assume this has items
    var carList = carEntityList.Select(s=>new Car { 
                                                    CarId = s.Id, 
                                                    CarColor = s.Color, 
                                                    CarModel = s.Model,
                                                    CarMake = s.Make
                                                  }
                                      );
