            public DelegateCommand MenuItemCommand { get; set; }
            
            public void InitCommands()
            {
                MenuItemCommand = new DelegateCommand(MenuItemClicked);                            
            }
    
            private void MenuItemClicked()
            {
                //do something when clicked
            }
