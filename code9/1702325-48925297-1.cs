    var source = new List<Car>();
    source.Add(new Car { ID = 1, Model = "Model A" });
    source.Add(new Car { ID = 1, Model = "Model B" });
    source.Add(new Car { ID = 1, Model = "Model B" });
    source.Add(new Car { ID = 1, Model = "Model B" });
    source.Add(new Car { ID = 1, Model = "Model A" });
    source.Add(new Car { ID = 1, Model = "Model A" });
    var result = new List<Result>();
    if (source.Any())
    {
        string model = source[0].Model;
        int count = 0;
        foreach (var car in source)
        {
            if (car.Model == model)
            {
                count++;
            }
            else
            {
                result.Add(new Result { Model = model, Count = count });
                model = car.Model;
                count = 1;
            }
        }
        result.Add(new Result { Model = model, Count = count });
    }
    foreach (var r in result)
    {
        Console.WriteLine(r.Model + " - " + r.Count);
    }
