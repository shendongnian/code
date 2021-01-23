    public ICommand CommandWhichDoesNotFire{get;set;}
    public MainViewModel()
    {
        MessageBox.Show("VM is real");
        CommandWhichDoesNotFire= new TestCommand(MyCommand);
    }
    private void MyCommand(object obj){
    //Whatever you want to do
    }
