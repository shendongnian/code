    //with some validation to enable/disable button click
    public virtual ICommand SearchCommand => new RelayCommand(o=> Search(), o=> Validation());
    //without validation
   
     public virtual ICommand SearchCommand => new RelayCommand(o=> Search());
    private void Search()
    {
    
    }
    private bool Validation()
    {
        
    }
    //using parametres
    public virtual ICommand SearchCommand => new RelayCommand(Search);
    private void Search(object parameter)
    {
        
    }
