    cts = new CancellationTokenSource();
    ct = cts.Token;
    //Result.Clear(); <-- I only changed this to
    //Result = new ObservableCollection<T>(); // <-- this
    // Outdated, currently using Result.RemoveAt(0); <-- See code edit
