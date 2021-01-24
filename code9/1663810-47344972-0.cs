    public static ReadOnlyReactiveProperty<Feature> GetRunningFeature(IEnumerable<Feature> features)
            {
                return Observable.Create<Feature>(obs =>
                    {
                        var disposables = new CompositeDisposable();
    
                        foreach (var feature in features)
                            feature.IsRunning.Subscribe(_ =>
                                    obs.OnNext(features.First(f => f.IsRunning.Value)))
                                .AddTo(disposables);
    
                        return Disposable.Create(() => disposables.Dispose());
                    })
                    .ToReadOnlyReactiveProperty();
            }
