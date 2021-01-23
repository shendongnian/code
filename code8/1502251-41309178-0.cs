    public ExampleClass1 objClass1 {
        get { return _objClass1; }
        set {
            //in case one already existed. unsubscribe from event
            if(_objClass1 != null) _objClass1.PropertyChanged -= base.Update
            _objClass1 = value;
            //subscribe to event
            if(_objClass1 != null) _objClass1.PropertyChanged += base.Update
            PropertyChanged?.Invoke(this,  new PropertyChangedEventArgs("objClass1"));               
        }
    }
