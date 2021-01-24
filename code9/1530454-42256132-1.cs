    public DateTime Starttime 
    {
        get 
         {
            if (this.Count > 0) 
            {
                 return this.Keys.Min();    
            }
            return new DateTime(2999,1,1);;
         }
    }
    public DateTime AvgVal {
        get {
            if (this.Count > 0) {
                return this.Keys.Average();
            }
            else    return DateTime.MinValue; 
         }
