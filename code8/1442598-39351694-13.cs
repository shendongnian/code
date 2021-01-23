    Value = Observable.Create<LibrarySettings>(observer =>
    {
        observer.OnNext(new LibrarySettings(false, OperationOneEnabled, OperationOneRate, OperationTwoEnabled, OperationTwoRate));
        return Disposable.Empty;
    });  
}
    public IObservable<LibrarySettings> Value
    {
         get { return _Value; }
         set { _Value = value; }
    }
    public void Write(LibrarySettings item)
    {
         Value = Observable.Create<LibrarySettings>(observer =>
        {
            observer.OnNext(new LibrarySettings(false, OperationOneEnabled,
            OperationOneRate, OperationTwoEnabled, OperationTwoRate));
            return Disposable.Empty;
        });
    }
