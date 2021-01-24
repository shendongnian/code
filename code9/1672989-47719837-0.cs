    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<UserData> UserData { get; }
            = new ObservableCollection<UserData>();
        private UserData selectedUserData;
        public UserData SelectedUserData
        {
            get { return selectedUserData; }
            set
            {
                selectedUserData = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedUserData)));
            }
        }
    }
