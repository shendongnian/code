    public class BigHouseConstruction: HouseConstruction
    {
        private HouseConstruction _basicConstruction;
        public BigHouseConstruction(HouseConstruction basic)
        {
            _basicConstruction = basic;
        }
        public overrides void Build()
        {
            _basicConstruction.Build();
            BuildSecondFloor();
        }
        private void BuildSecondFloor()
        {
            Console.WriteLine("Build second floor");
        }
    }
 
