    public class UserViewModel : BindableBase //use the BindableBase class
    {
        private ObservableCollection<User> _userList; //use the correct Model class (the newly created or Database.User if it is sufficient)
        public ObservableCollection<User> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }
        //wrapper for SelectedUser.Name
        public string SelectedUserName
        {
            get { return SelectedUser.Name; }
            set
            {
                SelectedUser.Name = value;
                OnPropertyChanged(nameof(SelectedUserName));
            }
        }
        //add wrappers for the other properties
        private User _selectedUser; //use the correct Model class (the newly created or Database.User if it is sufficient)
        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser)); // call the OnPropertyChanged of BindableBase (I would also recommend using nameof)
                OnPropertyChanged(nameof(SelectedUserName));
                //call OnPropertyChanged for the other wrapper properties
            }
        }
        public UserViewModel()
        {
            UserManager manager = new UserManager();
            var FilterCombo = new List<ComboItem> { 
                new ComboItem{Text = "Name", Value = "Name"},
                new ComboItem{Text = "Owner", Value = "Owner"},
                new ComboItem{Text = "Email", Value = "Email"},
                new ComboItem{Text = "Contact Number", Value = "Contact"},
                new ComboItem{Text = "Address", Value = "Address"},
            };
            var filter = new FilterModel
            {
                FilterItems = FilterCombo,
                FilterSelected = FilterCombo.Where(t => t.Text == "Name").FirstOrDefault(),
                FilterValue = ""
            };
            _userList = new ObservableCollection<User>(manager.GetList(filter).ToModels()); //this uses now the extension method (your manager should be doing the converting and return the model instead of the database user if the database user class is not sufficient)
        }
    }
