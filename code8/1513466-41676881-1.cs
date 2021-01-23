    private ICommand lostFocusCommand;
    public ICommand LostFocusCommand
    {
    	get { return lostFocusCommand ?? (lostFocusCommand = new RelayCommand(p => CostOutLostFocus())); }
    }
