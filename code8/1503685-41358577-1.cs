     public ICommand NextCommand
     {
         get
         {
             return _nextCommand = _nextCommand ?? new RelayCommand(Next, CanExecuteNext);
         }
     }
    
     private void Next()
     {
         start += itemCount;
         RefreshData();
     }
    
     private bool CanExecuteNext()
     {
         return start + itemCount < totalItems ? true : false;
     }
