    public class SwitchBoard
    {
        public List<ISwitchable> switchableDevices { get; private set; }
        public int TotalSwichableDevices
        {
            get { return numberOfFans + numberOfACs + numberOfBulbs; }
        }
        private readonly int numberOfFans;
        private readonly int numberOfACs;
        private readonly int numberOfBulbs;
        public SwitchBoard(int noOfFans, int noOfACs, int noOfBulbs)
        {
            this.numberOfFans = noOfFans;
            this.numberOfACs = noOfACs;
            this.numberOfBulbs = noOfBulbs;
            switchableDevices = new List<ISwitchable>();
            switchableDevices.AddRange(this.AddFans());
            //TODO: Add other devices
        }
        private IEnumerable<ISwitchable> AddFans()
        {
            List<ISwitchable> fans = new List<ISwitchable>();
            for (int i = 0; i < numberOfFans; i++)
            {
                fans.Add(new Fan());
            }
            return fans;
        }
    }
