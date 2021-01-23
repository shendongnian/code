    private ObservableCollection<Result> _Results;
    public ObservableCollection<Result> Results 
    {
        get { return this._Results; }
        set
        {
            this._Results= value;
            RaisePropertyChanged("Results");           
        }
    }
