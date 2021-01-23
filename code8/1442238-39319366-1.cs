    public class UserViewModel : BindableBase
    {
        private ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
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
        private UserModel _selectedUser;
        public UserModel SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
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
            _userList = new ObservableCollection<UserModel>(manager.GetList(filter));
        }
    }
