    public class MyModel
    {
        private decimal demand;
        public decimal Demand 
        { 
            get { return this.demand; }
            set { this.demand = value; }
        }
        private decimal supply;
        public decimal Supply 
        { 
            get { return this.supply; }
            set { this.supply = value; }
        }
        private DateTime date;
        public DateTime Date
        { 
            get { return this.date; }
            set { this.supply = value; }
        }
        private string dateString;
        public string DateString
        { 
            get { return this.dateString; }
            set { this.dateString = value; }
        }
    }
