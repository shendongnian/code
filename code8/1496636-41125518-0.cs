    public class ViewModel
    {
        public ViewModel()
        {
            AllUsers = new ObservableCollection<User>();
            AllUsers = CollectionViewSource.GetDefaultView(UserSource);
            //...
        }
        public ObservableCollection<User> UserSource
        {
            { get; private set; }
        }
        public ICollectionView AllUsers
        {
            { get; private set; }
        }
    }
