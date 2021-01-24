    public List<Vehicle> vehicleList { get; set; }
    
    class Vehicle
    {
        //A vehicle can be a car and must have an ID, a price and a licenseplate number.
        public int iD { get; set; }
        public double price { get; set; }
        public string licensePlate { get; set; }
        public typeVehicle type;
    
        //Constructor of vehicle, type of vehicle will be parsed from string to enum.
        public Vehicle(int iD, string typeName, double price, string license)
        {
            this.iD = iD;
            this.type = (typeVehicle)Enum.Parse(typeof(typeVehicle), typeName);
        }
    }
    
        //Get the price of the vehicle with parameter ID.
        public double getPriceVehicle(int iD)
        {
            if (iD < 0 || iD >= vehicleList.Count)
               throw new ArgumentOutOfRangeException("iD");
    
            var vehicle = vehicleList.FirstOrDefault(v => v.iD == iD);
            return vehicle == null ? double.NaN : vehicle.price;
        }
