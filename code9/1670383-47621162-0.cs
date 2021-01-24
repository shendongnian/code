    private async void LoadData()
    {
        var emps = new RootObject();
    
        emps = await apiServices.GetRootObject();
    
        RootObjects.Clear();
        
        //Mistake:
        //You iterate through the previously cleared observable collection.
        //it really should be "foreach (var item in emps.Items)"
        foreach (var item in RootObjects)
        {
    
            RootObjects.Add(new RootItemViewModel
            {
    
    
            });
        }
    }
