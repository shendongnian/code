    public DelegateCommand AddFolderCommand { get; protected set; }
    public MyViewModel(ExplorerViewModel explorer)
    {           
        AddFolderCommand = new DelegateCommand(ExecuteAddFolderCommand, (x) => true);
    }
    public void ExecuteAddFolderCommand(object param)
    {          
        MessageBox.Show("this will be executed on button click later");
    }
