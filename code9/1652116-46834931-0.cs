    private string _dynamicGif = "test.gif";
    public string DynamicGif
    {
        get { return _dynamicGif; }
        private set
        {
            _dynamicGif = value;
            RaisePropertyChanged("DynamicGif");
        }
    }
