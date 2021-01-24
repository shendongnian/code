    private ICommand _doWhateverCommand;
    public ICommand DoWhateverCommand
    {
    	get
    	{
    		if (_doWhateverCommand == null)
    		{
    			_doWhateverCommand = new RelayCommand(
    				() => { /* do your stuff with SelectedItem here */  },
    				() => { return SelectedItem != null; }
    			);
    		}
    		return _doWhateverCommand;
    	}
    }
