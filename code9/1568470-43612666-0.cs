    class Vehicle
    {
        static Vehicle()
        {
            spawnVehicle();
        }
    
        public static int vehCount = 0;
        static void spawnVehicle()
        {
            Timer tm = new Timer();
            tm.Interval = 1500;
            tm.Elapsed += (s, e) => vehCount++;
            vehCount++;
            tm.Start();
        }
    }
