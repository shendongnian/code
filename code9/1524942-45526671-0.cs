    public partial class WeeklyGraphGroup
    {
        public int ? Year { get; set; }
        public int  ? Week { get; set; }
        public int Source { get; set; }
    }
    public partial class WeeklyGraphGroup
    {
        private int ? _Total;
        public int ? Total
        {
           
            get
            {
                this._Total = CalculateTotal(this.Year, this.Week, this.Source);
                return this._Total;
            }
        }
        public int ? CalculateTotal(int ? Year, int ? Week, int Source)
        {
            // do your calculation and return the value of total
            // use whatever formula you want here. I guess you are calculating 
            // total based on any of the parameters(year, week or source);
            return value;
        }
        
    }
