    var scheduler = new TestScheduler();
    
    //Convert to array of OnNext notifications and create an Observable
    var history = stocks.Select(i => OnNext(i.Time.Ticks, i)).ToArray();
    var stockHistoryObservable = scheduler.CreateHotObservable(history);
    //Create an observer and subscribe
    var observer = scheduler.CreateObserver<StockTickerChangeHistory>();
    stockHistoryObservable.Subscribe(observer);
    scheduler.AdvanceTo(dateWhenNoHistoryYet); //no history
    observer.Messages.AssertEqual(); 
    scheduler.AdvanceTo(dateWhenHistoryIsCompleted); //all history arrived
    observer.Messages.AssertEqual(history); 
