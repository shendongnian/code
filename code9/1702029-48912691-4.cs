     public ICommand ExecuteButtonCommand
     {
         get
         {
             if (_executeButtonCommand == null)
                 _executeButtonCommand = new RelayCommand(ButtonCommands);
             return _executeButtonCommand;
         }
     }
