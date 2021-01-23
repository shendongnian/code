    List<Car> list = db.Cars.Where(c => c.OwnerId == id).ToList();
    
    //Delete all cars
    foreach(Car car in list){
        db.Cars.Remove(car);
        db.SaveChanges();
    }
    
    Owner owner = db.Owners.Find(id);
    db.Owners.Remove(owner);
    db.SaveChanges();
