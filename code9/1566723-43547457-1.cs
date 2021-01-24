    private JObject _dataObj;
    public JObject DataObj {
        get { return _dataObj; }
        set {
            if (_dataObj != value) {
                _dataObj = value;
                OnDataObjChanged();
                //  Maybe you don't really need this, I can't say. 
                //OnPropertyChanged(nameof(DataObj));
            }
        }
    }
    protected async void OnDataObjChanged()
    {
        await 
            dataBox.Dispatcher.RunAsync(
                Windows.UI.Core.CoreDispatcherPriority.Normal, 
                delegate { _dataBox.Text = writeString; }
            );
    }
