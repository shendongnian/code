    // Your Car Class
    public class Car
    {
        public string Producer{ get; set; }
        public string Colour{ get; set; }
        public int LicensePlate { get; set; }
        public int CarID { get; set; }
    }
    
    // The List<Car>
    var cars= new List<Car>(){ 
        new Car() { Producer= "Ford", Colour= "Red", LicensePlate= 123},
        new Car() { Producer= "Chevy", Colour= "Green", LicensePlate= 333}       
        };
    
    // Build the document
    public static void SaveFileAuto(List<Car> cars)
    {
      XDocument xdoc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
            // This is the root of the document
            new XElement("Cars", 
            from car in cars
            select
                new XElement("Car", new XAttribute("ID", car.CarID),
                new XElement("Producer",car.Producer),
                new XElement("Colour", car.Colour),
                new XElement("LicensePlate", car.LicensePlate));
                
       // Write the document to the file system            
       xdoc.Save("C:/Working Directory/Cars.xml");
    }
    
