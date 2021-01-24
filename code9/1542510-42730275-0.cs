    //Fires an event right away so search is cancelled faster
    var searchEntered = this.WhenAnyValue(vm => vm.SearchString)
        .Where(x => !String.IsNullOrWhiteSpace(x))
        .Publish()
        .RefCount();
    
    
    
    ReactiveCommand<string, string> searchCmd = ReactiveCommand.CreateFromObservable<string, string>(
        (searchString) => Observable.StartAsync(ct => CancellableSearch(SearchString, ct))
                        .TakeUntil(searchEntered));
    
    //if triggered wait for IsExecuting to transition back to false before firing command again
    var searchTrigger = 
        searchEntered
            .Throttle(TimeSpan.FromMilliseconds(500))
            .Select(searchString => searchCmd.IsExecuting.Where(e => !e).Take(1).Select(_ => searchString))
            .Publish()
            .RefCount();
    
    _IsSearching =
        searchCmd.IsExecuting
        .ToProperty(this, vm => vm.IsSearching);
    
    
    searchTrigger
        .Switch()
        .InvokeCommand(searchCmd);
