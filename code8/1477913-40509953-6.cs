    private bool isSelected; 
    public bool IsSelected
    {
       get 
       {
          return isSelected;
       }
       set 
       {
          isSelected = value;
          OnPropertyChanged("IsSelected");
       }    
    }
