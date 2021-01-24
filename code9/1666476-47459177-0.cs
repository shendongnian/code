    interface IExample {
     
        bool IsEliminated { get; set; }
    
    }
    public void Delete<T>(List<T> data) where T : IExample
    {      
        if (data != null)
        {
            data.ForEach(x =>
            {
               x.Eliminated = true;
            });
        }           
    }
