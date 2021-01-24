     public AddRoleViewModel(Action<UserRoleClass> onAdded = null)
        {
            _addOrUpdate = new UserRoleClass();          
            _addOrUpdate = new UserRoleClass();
            _onAdded = onAdded;
            saveRole = new RelayCommand<Window>(addFunc);           
        }
    
        private void addFunc(Window window)
        {
            UserRoleClass newRole = new UserRoleClass()
            {
                name = AddOrUpdate.name,
                description = AddOrUpdate.description,
            };                                             
                 int resultSave = WCFclient.saveRole(newRole);          
                if (resultSave == 0)
                 {
                     String UpdateInformation0 = "Role is saved successfully";
                     string sCaption = "Save Role";
                     MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                     MessageBoxImage icnMessageBox = MessageBoxImage.Information;
                     MessageBoxResult rsltMessageBox = MessageBox.Show(UpdateInformation0, sCaption, btnMessageBox, icnMessageBox);
                 }           
    
             }
             _onAdded?.Invoke(newRole);           
             if (window != null)
             {
                 window.Close();
             }       
    
