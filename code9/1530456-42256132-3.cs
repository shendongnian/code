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
    public DateTime AvgVal 
    {
        get
        {
            if (this.Count > 0) 
               return this.Values.Average();  
            else    
               return DateTime.MinValue; //something must be returned.
       }
    }
