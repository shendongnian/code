     public async Task<DataContext> GetDataAsync()
    {
        DataContext data = new DataContext();
    //crate individual tasks
        var test1 = _dac.GetProductsAsync();
        var test2 = _dac.GetProducts2Async();
        var test3 = _dac.GetProducts3Async();
        var test4 = _dac.GetProducts4Async();
        var test5 = _dac.GetProducts5Async();
    //Execute all tasks at once with WhenAll function
        await Task.WhenAll(task1, task2, task3, task4, task5); 
    //This statement is executed only after all the tasks are finished	
    	return data;
    }
