    public ReactiveCommand<string, IEnumerable<T>> GetItemsCommand { get; set; }
    GetItemsCommand.CreateFromObservable<string, IEnumerable<T>>(x =>
        Observable.FromAsync(token =>
            _itemService.GetItemsAsyncWithCancelation(x.ToString(), token)));
    // always runs on UI thread
    GetItemsCommand.Subscribe(x => Items = x);
