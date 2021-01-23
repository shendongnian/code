        public ICommand StartupCommand
        {
            get
            {
                return new RelayCommand(async ()=>
                {
                    this.AccountName = await
                            dialogCoordinator.ShowInputAsync(this, "Welcome", "Please insert your account name");                    
                });
            }
        }
