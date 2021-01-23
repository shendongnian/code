	var focusedObservable =
        Observable
            .FromEventPattern<FocusEventArgs>(
                x => _totalBirds.Entry.Focused += x,
                x => _totalBirds.Entry.Focused -= x)
            .Select(x => x.EventArgs.IsFocused);
        focusedObservable 
            .WhenIsTrue() // extension method, basically .Where(x => x)
            .ObserveOn(RxApp.MainThreadScheduler)
            .InvokeCommand(this, x => DoSomething)
			.DisposeWith(ControlBindings); // extension that uses composite disposable
	    focusedObservable
            .WhenIsFalse() // extension method, basically .Where(x => !x)
			.ObserveOn(RxApp.MainThreadScheduler)
            .InvokeCommand(this, x => x.ViewModel.DoSomethingElse)
            .DisposeWith(ControlBindings); // extension that uses composite disposable
