    public class KawasakiNinja : Motorcycle {
        private int _gas;
    
        public KawasakiNinja()
        {
            _gas = 100;
        }
    
    
        public override int Drive(int miles, int speed)
        {
            var timeWhateverValue = miles / speed;
    
            _gas -= timeWhateverValue;
            return timeWhateverValue;
        }
    
        public override double GetTopSpeed()
        {
            return 300;
        }
    
        protected override void AddGas(int gallons)
        {
            _gas += gallons;
        }
        
        public void FillErUp(int gallons)
        {
            AddGas(gallons);
        }
    }
