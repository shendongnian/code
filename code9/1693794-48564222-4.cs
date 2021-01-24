    public DelegateCommand SaveCommand { get; private set; }
       
    SaveCommand = new DelegateCommand(SaveItem, canExecute)
            .ObservesProperty(() => this.Name)
            .ObservesProperty(() => this.Title)
            .ObservesProperty(() => this.Description);
            
    public bool canExecute()
    {
        return !string.IsNullOrEmpty(this.Name) &&    !string.IsNullOrEmpty(this.Title) && !string.IsNullOrEmpty(this.Description);
    }
   
    private async void SaveItem()
        {
           //Put your saving logic here.
        }
