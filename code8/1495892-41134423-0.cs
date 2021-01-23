    public ReactiveCommand<Unit> btnClick { get; private set; }
        public VMUpdates(frmMain frmMain)
        {
            ...
            btnClick = ReactiveCommand.CreateAsyncObservable(x => ExecutableMethod());            
        }
        public IObservable<Unit> ExecutableMethod()
        {
            return Observable.Start(() => {
                ...
            });
        }
