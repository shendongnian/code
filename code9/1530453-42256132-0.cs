    public DateTime Starttime 
    {
        get 
         {
            if (this.Count > 0) 
            {
                 return Diversion.Keys.Min();    
            }
            return new DateTime(2999,1,1);;
         }
    }
    public DateTime AvgVal {
        get {
            if (this.Count > 0) {
                return Diversion.Keys.Average();
            }
            else    return; 
         }
