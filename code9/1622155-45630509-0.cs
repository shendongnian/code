        var items = new List<dynamic>();
        
                    var testObjectOne = new
                    {
                        Valueone = "test1",
                        ValueTwo = "test2",
                        ValueThree = "test3"
                    };
     items.Add(testObjectOne);
    items.Add(testObjectTwo);
    
                foreach (var obj in items)
                {
                    var val = obj.Valueone;
                }
