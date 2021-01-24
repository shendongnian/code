    public class TrafficReport
    {
        private int[] vehicles;
        private double[] percentages;
        public TrafficReport(int[] vehiclesPerHour, double[] trafficPercentages)
        {
            vehicles = vehiclesPerHour;
            percentages = trafficPercentages;
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine("Traffic Report");
            Console.WriteLine("-----------------------");
            Console.WriteLine("{0}{1,24}", "Hour", "\tNumber of vehicles  Percent");
            for (int hour = 0; hour < percentages.Length; ++hour)
            {
                Console.WriteLine("{0,3}{1,14}{2,18:P}", hour, vehicles[hour], percentages[hour]);
            }
        }
    }
