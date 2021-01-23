    public class Car
    {
        public string car_name { get; set; }
        public string car_brand { get; set; }
        public int car_year { get; set; }
        public Car(string name, string brand, int year)
        {
            car_brand = brand;
            car_name = name;
            car_year = year;
        }
    }
