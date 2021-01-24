    public TOriginal Original
    {
        get { return _original; }
        set { this.RaiseAndSetIfChanged(ref _original, value); }
    }
    TOriginal _original;
    public TDerived Derived { get { return _derived.Value; } }
    readonly ObservableAsPropertyHelper<double[,]> _derived;
    _derived = this.WhenAnyValue(x => x.Original)
        .Where(originalValue => originalValue != null)
        // Sepcify the scheduler to the operator directly
        .SelectMany(originalValue =>
            Observable.Start(
                () => LongRunningCalculation(originalValue),
                RxApp.TaskPoolScheduler))
        .ObserveOn(RxApp.MainThreadScheduler)
        // I prefer this overload of ToProperty, which returns an ObservableAsPropertyHelper
        .ToProperty(this, x => x.Derived);
