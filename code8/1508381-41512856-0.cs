    public ObservableCollection<string> _state = new ObservableCollection<string>();
    public ObservableCollection<string> States 
    {
     get{return _state;}
    set {_state = value; OnPropertyChange("States");}
    }
