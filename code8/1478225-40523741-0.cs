    public void AddCars(int recordID, List<Cars> carsToSave) {
         foreach(Cars car in carsToSave){
            car.RecordID = recordID;
            _db.Cars.Add(car);
         }
         _db.SaveChanges();
    }
    public void EditCars(List<Cars> carsToEdit){
        foreach(Cars car in carsToEdit){
            Cars editCar = this.Find(car.Id);
            editCar.EmptyOrLoaded = car.EmptyOrLoaded;
            editCar.CarType = car.CarType;  
            editCar.ShippedBy = car.ShippedBy; 
            editCar.RailcarNumber = car.RailcarNumber;  
            editCar.ApplicationUser = car.ApplicationUser;  
            editCar.UserId = car.UserId;  
            _db.SaveChanges();
         }
    }
