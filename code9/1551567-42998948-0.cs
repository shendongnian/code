    public bool FilterRecords(object obj)
    {
        if(obj is Customer) 
        {
            var customer = (Customer)obj;
            //... 
        }
        else if(obj is Order)
        {
            var order = (Order)obj;
            //... 
        }
        //... 
    } 
