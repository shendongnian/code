    var MyViewModel = new MyViewModel();
    var MyDomainModel = AutoMapper.Map<MyDomainModel>(MyViewModel);
    MyDomainModel = service.DoSomething(MyDomainModel);
    public MyDomainModel DoSomething(MyDomainModel model)
    {
        MyDomainModel newModel = new MyDomainModel();
        newModel.Property1 = model.Property1;
    
        return newModel;
    }
