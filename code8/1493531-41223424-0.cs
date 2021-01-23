    public NotifyTask<Result> MyFunctionResults { get { ... } private set { ... /* raise PropertyChanged */ } }
    public ICommand StartMyFunction { get; } = new DelegateCommand(() =>
    {
      MyFunctionResults = NotifyTask.Create(MyFunctionAsync());
    });
