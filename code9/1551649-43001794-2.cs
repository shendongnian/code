    private ReadOnlyCollection<String> _states;
    public ReadOnlyCollection<String> States; {
        get { 
            if (_states == null) {
                _states = new ReadOnlyCollection(DB.GetStates().ToList());
            }
            return _states;
        }
     }
