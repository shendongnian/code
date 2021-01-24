        private RelayCommand cellEditingCommand;
        public ICommand CellEditCommand
        {
            get
            {
                if (cellEditingCommand == null)
                {
                    cellEditingCommand = new RelayCommand(CellEdit, CanCellEdit);
                }
                return cellEditingCommand;
            }
        }
       
        private bool CanCellEdit(object parameter)
        {
            return true;
        }
        
        private void CellEdit(object parameter)
        {
            Pool.isEdit = true;
        }
