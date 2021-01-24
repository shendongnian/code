    `public ICommand Load
     {
        get
        {
           RelayCommand<object> load= new RelayCommand<object((parameter) =>     LoadGame(parameter));
           return load;
        }
     }`
