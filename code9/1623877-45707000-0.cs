    isMessageVisible = this
        .WhenAnyValue(x => x.Message, x => !string.IsNullOrEmpty(x))
        .Select(showMessage => Observable.Return(showMessage).Concat(Observable.Return(false).Delay(4, RxApp.MainThreadScheduler)))
        .Switch()
        .ToProperty(this, x => x.IsMessageVisible);
