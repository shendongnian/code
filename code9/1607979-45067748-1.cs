    public void AddIfNotExists(Model1 model1)
    {
        //No Need for the include this is executed in sql,  assuming the model 2 
        //property has already been included in your model1 this should work fine
        if(false == _context.Model1.Any(x => x.Name1 == model1.Name1 
                            && x.Model2.Name2 == model1.Model2.Name2))
        {
            _context.Model1.Add(model1);
        }
    }
