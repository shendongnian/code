    private ICommand doWhateverCommand;
    public ICommand DoWhateverCommand
    {
    	get
    	{
    		if (doWhateverCommand == null)
    		{
    			doWhateverCommand = new RelayCommand(
    				() => { /* do your stuff with SelectedItem here */  },
    				() => { return SelectedItem != null; }
    			);
    		}
    		return doWhateverCommand;
    	}
    }
