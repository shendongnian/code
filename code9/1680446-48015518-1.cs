    var MyViewModel = new MyViewModel();
    var MyDomainModel = AutoMapper.Map<MyDomainModel>(MyViewModel);
    service.DoSomething(MyDomainModel);
    
    public void DoSomething(MyDomainModel model)
    {
        model.Property1 = X;
        model.Property2 = Y;
    }
