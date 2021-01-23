    public class Car
    {
        public int CarHouseID { set; get; }
        public int CarsInHouse{ set; get; }
        public int CarSold    { set; get; }
        public static Car GetCar()
        {
            return new Car();
        }
    }
