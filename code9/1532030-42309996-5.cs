    public class TrafficReport
    {
        private int[] vehiclesPerHour;
        private double[] trafficPercentage;
        public TrafficReport(int[] vehicles)
        {
            vehiclesPerHour = vehicles;
        }
        public void Print()
        {
            PrepareData();
            ShowData();
        }
        private void PrepareData()
        {
            int numberOfVehicles = vehiclesPerHour.Sum();
            trafficPercentage = new double[vehiclesPerHour.Length];
            for (int i = 0; i < vehiclesPerHour.Length; ++i)
            {
                trafficPercentage[i] = ((double) vehiclesPerHour[i]) / numberOfVehicles;
            }
        } 
        private void ShowData()
        {
            Console.Clear();
            Console.WriteLine("Traffic Report");
            Console.WriteLine("-----------------------");
            Console.WriteLine("{0}{1,24}", "Hour", "\tNumber of vehicles  Percent");
            for (int hour = 0; hour < trafficPercentage.Length; ++hour)
            {
                Console.WriteLine("{0,3}{1,14}{2,18:P}", hour, vehiclesPerHour[hour], trafficPercentage[hour]);
            }
        }
    }
