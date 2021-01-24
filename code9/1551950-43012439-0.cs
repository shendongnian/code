    public class Attributes
    {
        // PrimaryAttributes
        public class PrimaryAttr
        {
            public int Strength { get; set; }
            public int Agility { get; set; }
            public int Stamina { get; set; }
            public int Intellect { get; set; }
            public int Wisdom { get; set; }
            public int Spirit { get; set; }
        }
    
        private PrimaryAttr _primaryAttr;
        public PrimaryAttr PrimaryAttributes
        {
            get
            {
                if (this._primaryAttr == null)
                    this._primaryAttr = new PrimaryAttr();
    
                return this._primaryAttr;
            }
        }
    
        // ProbabilisticAttributes
        public class ProbabilisticAttr
        {
            public int Evasion { get; set; }
            public int Accuracy { get; set; }
            public int CriticalStrike { get; set; }
        }
    
        private ProbabilisticAttr _probabilisticAttr;
        public ProbabilisticAttr ProbabilisticAttributes
        {
            get
            {
                if (this._probabilisticAttr == null)
                    this._probabilisticAttr = new ProbabilisticAttr();
    
                return this._probabilisticAttr;
            }
        }
    
        // LogisticalAttributes
        public class LogisticalAttr
        {
            public int Movement { get; set; }
            public int Initiative { get; set; }
            public int Jump { get; set; }
        }
    
        private LogisticalAttr _logisticalAttr;
        public LogisticalAttr LogisticalAttributes
        {
            get
            {
                if (this._logisticalAttr == null)
                    this._logisticalAttr = new LogisticalAttr();
    
                return this._logisticalAttr;
            }
        }
        // Rest of the implementation    
        public Attributes()
        {
            // Don't have to declare or initialize anything.
        }
    
        public int ReturnSomethingAmazing()
        {
            return this.PrimaryAttributes.Strength * this.PrimaryAttributes.Agility; // Notice the group accessor usage.
        }
    
        // Do more stuff here
    
    
    }
