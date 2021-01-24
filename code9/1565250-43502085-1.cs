    ViewModelBase
    {
	    public virtual ICommand CompositeCommand { get; } = new RelayCommand<object>((arg) =>
	    {
		    DeleteCustom.Execute(null);
		    CancelCommand.Execute(null);
	    });
	
	    protected virtual DeleteCustom(object arg)
	    {
           /.....
	    }
	
	    protected virtual CancelCommand(object arg)
	    {
            /....
	    }
	
	    //..........
    }
    FirstViewModel : ViewModelBase
    {
        // ...............
	    protected override void  DeleteCustom(object arg)
	    {
	    }
        // ..........
    }
    SecondviewModel : ViewModelBase
    {
         // ...............
	    protected override void  CancelCommand(object arg)
	    { 
	    }
        // ..........
    }
