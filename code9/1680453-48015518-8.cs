    public MyDomainModel DoSomething()
    {
        // ...
    
        return (new MyDomainModel());
    }
    var MyViewModel = new MyViewModel();
    var MyDomainModel = AutoMapper.Map<MyDomainModel>(MyViewModel);
    MyDomainModel = service.DoSomething();
