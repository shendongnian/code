    public ObservableCollection<MLField> Fields
    {
        get { return _Fields; }
        set
        {
            if (_Fields != value)
            {
                _Fields = value;
                NotifyPropertyChanged();
            }
        }
    }
    private ObservableCollection<MLField> _Fields;
