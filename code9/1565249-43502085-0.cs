    ViewModelBase
    {
	    public virtual ICommand CompositeCommand { get; } = new RelayCommand<object>((arg) =>
	    {
		    Command1.Execute(null);
		    Command2.Execute(null);
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
	    protected override void  Command1(object arg)
	    {
	    }
        // ..........
    }
    SecondviewModel : ViewModelBase
    {
         // ...............
	    protected override void  Command2(object arg)
	    { 
	    }
        // ..........
    }
