    class Program
        {
            static void Main(string[] args)
            {
    
                var John = new Customers
                {
                    Name = "John",
                    FlightId = 24
                };
    
                var Flight = new FlightInformation
                {
                    Id=24,
                    Destination="Cyprus"
                };
    
                Flight.Passengers.Add(John);
    
                //Code to search for flights
    
                //code to search for passengers
    
                
    
            }
        }
