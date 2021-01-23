        public static Dictionary<string, ViewModelBase> LoadDictionary()
        {
             return new Dictionary<string, ViewModelBase>() { 
                 {"LoginView", new LoginViewModel()},
                 {"SignUpView", new SignUpViewModel()}, 
                 {"ContactListView", new ContactListViewModel()} 
             };
        }
