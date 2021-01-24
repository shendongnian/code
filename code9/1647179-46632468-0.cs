    void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
    { 
        if(args.PropertyName != nameof(CurrentSocialMedia))
            return;
        var oldObservable = oldValue as INotifyCollectionChanged;
        if (oldObservable != null)
            oldObservable.CollectionChanged -= CollectionChanged;
        var newObservable = newValue as INotifyCollectionChanged;
        if (newObservable != null) {
            newObservable.CollectionChanged += CollectionChanged;
        }
    }
    void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        RaisePropertyChanged(nameof(CurrentSocialMedia));
    }
