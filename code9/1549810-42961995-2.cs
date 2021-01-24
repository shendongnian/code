    var action = new TransformBlock<SystemInfo, ImageDelta>(CalculateDelta,
        new ExecutionDataflowBlockOptions
        {
            // we can start as many item processing as processor count
            MaxDegreeOfParallelism = Environment.ProcessorCount,
        });
    IDisposable subscription = source.Subscribe(action.AsObserver());
    var uiObserver = action.AsObservable()
        .Select(x => x.ObserveOn(DispatcherScheduler.Current))
        .Select(x => UpdateUI(x));
