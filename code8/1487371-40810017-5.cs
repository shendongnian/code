    async Task ParserData(List<DataObject> MyObjcets)
    {
        var tasks = new List<Task>();
        foreach(var Obj in MyObjects)
        {
            //do some computation and add it to an instance of ResultObject 
            ResultObject result = new ResultObject();
            var task = SaveResultAsync(result );
            tasks.Add(task);
        }
        await Task.WhenAll(tasks.ToArray());
    }
