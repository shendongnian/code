    public class Car
    {
        public Car()
        {
            CarDrivers = new HashSet<CarDriver>();
        }
        public int CarId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
    
    public class Driver
    {
        public Driver()
        {
            CarDrivers = new HashSet<CarDriver>();
        }
        public int DriverId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
    
    public class CarDriver
    {
        [Key, Column(Order = 0), Index(IsUnique = true)]
        public int CarId { get; set; }
        [Key, Column(Order = 1), Index(IsUnique = true)]
        public int DriverId { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
    }
