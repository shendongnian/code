        public static Dictionary<string, ViewModelBase> LoadDictionary()
        {
            Dictionary<string, ViewModelBase> tempDictionary = new Dictionary<string, ViewModelBase>();
            tempDictionary.Add("LoginView", new LoginViewModel());
            tempDictionary.Add("SignUpView", new SignUpViewModel());
            tempDictionary.Add("ContactListView", new ContactListViewModel());
            return tempDictionary;
        }
