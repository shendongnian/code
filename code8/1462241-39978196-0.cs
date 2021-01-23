    public RelayCommand MyCommand { get; }
    public MyView()
    {
        //[...]
        this.MyCommand = new RelayCommand(this.ExecuteMyCommand, this.CanExecuteMyCommand);
    }
    public void ExecuteMyCommand()
    {
       //do work!
    }
    public bool CanExecuteMyCommand()
    {
       //optional - control if command can be executed at a given time
    }
