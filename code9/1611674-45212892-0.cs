    private ObservableCollection<StepResult> _stepResults;
    public ObservableCollection<StepResult> StepResults
    {
        get { return _stepResults; }
        set
        {
            if (_stepResult == value)
                return;
            _stepResults = value;
            OnPropertyChanged();
        }
    }
