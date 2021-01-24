    public class TestViewModel : ViewModelBase  
    {
        public TestViewModel() { }
    
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users= value;
                RaisePropertyChanged("Users");
            }
        }
    
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser= value;
                RaisePropertyChanged("SelectedUser");
            }
        }
    }
