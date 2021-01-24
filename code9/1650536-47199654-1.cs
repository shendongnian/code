 
     public void ObserveSelectedTemplateStream(IObservable<dto> textFromEventPatternStream)
                {
    
                    _compositeDisposable.Dispose(); // clean whatever subscriptions we have
                    _compositeDisposable = new CompositeDisposable();
    
                    var disposable = textFromEventPatternStream
                    .Select(x => Parse(x)) // simulating much heavier pre processing, leading to a possible error
                    .ObserveOn(_rxConcurrencyService.Dispatcher)
                    .Do(_ => IsLoading = true)
                    .ObserveOn(_rxConcurrencyService.TaskPool)
                    .SelectMany(x=> _mathApi.CalcAsync(x))
                    .ObserveOn(_rxConcurrencyService.Dispatcher)                    .Subscribe(Model.Update,
                        ex => {
                            HandleException(ex);
                            ObserveSelectedTemplateStream(textFromEventPatternStream); // Recursively resubscribe to our stream. We expect errors. It's an API.
                        });
    
                _compositeDisposable.Add(disposable);
    
    
            }
