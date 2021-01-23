    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Pump p1 = new Pump("Pump1");
    
                // Lets make sure to subscribe to StatusChanged event before you start the pump
                // with a new vehicle.
                p1.StatusChanged += StatusChanged;
    
                p1.Start(new Vehicle());
    
                Pump p2 = new Pump("Pump2");
                p2.StatusChanged += StatusChanged;
                p2.Start(new Vehicle());
    
                //Console.Write("Finished...");
                Console.ReadLine();
            }
               
        }
    
        // we can use the same handler for all pumps and we can do different things 
        // depending on who the sender is.
        // Or if you prefer, you can have different event handlers
        private static void StatusChanged(object sender, PumpEventArgs e)
        {
            var pump = sender as Pump;
            Console.WriteLine("{0} status changed to {1}.", pump.Name, e.Status);
        }
    }
