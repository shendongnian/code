    public class Traffic
    {
        private int[] trafficCount;
        public static void Main(string[] args)
        {
            Traffic traff = new Traffic(24);
            traff.showData();
        }
        public Traffic(int hours)
        {
            trafficCount = new int[hours];
            // populate with dummy data
            for (int i = 0; i < hours; i++)
            {
                trafficCount[i] = i*2+1; // replace this with real data
            }
        }
        public void showData()
        {
            Console.Clear();
            Console.WriteLine("Traffic Report");
            Console.WriteLine("-----------------------");
            long vehicleTotal = trafficCount.Sum();
            Console.WriteLine("{0}{1,24}", "Hour", "\tNumber of vehicles  Percent");
            for (int hour = 0; hour < trafficCount.Length; hour++)
            {
                var percentageInHour = (double)trafficCount[hour]/ vehicleTotal;
                Console.WriteLine("{0,5}{1,12}{2,17:P}", hour, trafficCount[hour], percentageInHour);
            }
        }
    }
