    public class TrafficScanner
    {
        private int[] vehiclesPerHour;
        public TrafficScanner(int hours)
        {
            vehiclesPerHour = new int[hours];
        }
        public void Read()
        {
            int hour = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "") break;
                int carsThisHours = 0;
                bool isParsedSuccessfully = Int32.TryParse(input, out carsThisHours);
                if (isParsedSuccessfully)
                {
                    vehiclesPerHour[hour++] += carsThisHours;
                }
                hour = hour % vehiclesPerHour.Length;
            }
        }
        public int[] Vehicles
        {
            get
            {
                return vehiclesPerHour;
            }
        }
    }
