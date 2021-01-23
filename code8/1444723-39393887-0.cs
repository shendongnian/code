     public class Vehicle
    {
        public string Name { get; set; }
        public virtual string GetCustomProperty() { return string.Empty; }
    }
    public class ElectricalDriven : Vehicle
    {
        public string ElectricalVehicleProperty { get; set; }
        public override string GetCustomProperty() { return ElectricalVehicleProperty; }
    }
    public class GasolinDriven : Vehicle
    {
        public string GasolinVehicleProprety { get; set; }
        public override string GetCustomProperty() { return GasolinVehicleProprety; }
    }
    static class Run
    {
        public static void Load()
        {
            var myListOfVechicles = new List<Vehicle>();
            myListOfVechicles.Add(new ElectricalDriven { Name = "Tesla", ElectricalVehicleProperty = "100 000" });
            myListOfVechicles.Add(new GasolinDriven { Name = "Ford", GasolinVehicleProprety = "50 000" });
            foreach (var row in myListOfVechicles)
            {
                Console.WriteLine("Price: " + row.GetCustomProperty()); //will output 100,000 and 50,000
            }
            Console.Read();
        }
    }
