     static void Main(string[] args)
            {
                string locationName = Console.ReadLine();
                
                var location = new GoogleLocationService();
                var point = location.GetLatLongFromAddress(locationName);
                
                Console.WriteLine(point.Latitude);
                Console.WriteLine(point.Longitude);
                Console.Read();
    
            }
