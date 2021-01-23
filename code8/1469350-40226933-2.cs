    var carEntityList= new List<CarEntity>(); //assume this has items
    var carList = carEntityList.Select(s=>new Car { 
                                                    Id = s.Id, 
                                                    Color = s.Color, 
                                                    Model = s.Model,
                                                    Make = s.Make
                                                  }
                                      );
