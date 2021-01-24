    public class SwitchBoard
    {
        public int TotalSwichableDevices
        {
            get
            {
                return numberOfFans + numberOfACs + numberOfBulbs;
            }
        }
        public List<ISwitchable> switchableDevices { get; set; }
    
        private readonly int numberOfFans;
        private readonly int numberOfACs;
        private readonly int numberOfBulbs;
    
        public SwitchBoard(int noOfFans, int noOfACs, int noOfBulbs)
        {
            this.numberOfFans = noOfFans;
            this.numberOfACs = noOfACs;
            this.numberOfBulbs = noOfBulbs;
    
            switchableDevices = new List<ISwitchable>();
            switchableDevices.AddRange(this.AddFans(noOfFans));
    
            //TODO: Add other devices
        }
    
        private IEnumerable<ISwitchable> AddFans(int noOfFans)
        {
            List<ISwitchable> fans = new List<ISwitchable>();
            for (int i = 0; i < noOfFans; i++)
            {
                fans.Add(new Fan());
            }
            return fans;
        }
    }
