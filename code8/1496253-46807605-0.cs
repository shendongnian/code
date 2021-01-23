    public class Vehicle
    {
        public string Type {get; set;} //you need the setter here for EF
    }
        
    public class Car : Vehicle
    {
        public Car()
        {
            Type = "Car";
        }
    }
    DataContext.Fleets
        .Include(x => x.Vehicles.Select(y => y.EngineData)) // Not specific to Car or Truck
        .Include(x => x.Vehicles.Where(x => x.Type == "Car").Select(y => y.BultinEntertainmentSystemData)) // Only Cars have BultinEntertainmentSystemData
        .ToList();
    
