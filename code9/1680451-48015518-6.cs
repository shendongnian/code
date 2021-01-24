    public void DoSomething(MyDomainModel model)
    {
        model.Property1 = X;
        model.Property2 = Y;
    }
    var MyViewModel = new MyViewModel();
    var MyDomainModel = AutoMapper.Map<MyDomainModel>(MyViewModel);
    service.DoSomething(MyDomainModel);
    // MyDomainModel.Property1 is set to X now...
