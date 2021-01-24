    private MyClass _selectedWorkItem;
    
    public MyClass SelectedWorkItem
    {
      get { return _selectedWorkItem; }
      set
      {
         _selectedWorkItem = value;
         EditWorkItemEntry.RaiseCanExecuteChanged();
      }
    }
