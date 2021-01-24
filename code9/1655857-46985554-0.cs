    public class MySingleton : INotifyPropertyChanged
    {
        private AutoResetEvent ownersResetEvent = new AutoResetEvent(true);
        private List<Owner> owners;
        private static MySingleton instance = new MySingleton();
        private MySingleton() => Initialize();
        public static MySingleton Instance => instance;
        public event PropertyChangedEventHandler PropertyChanged; 
        public IEnumerable<Owner> Owners 
        {
            get
            {
                ownersResetEvent.WaitOne();
                var tempOwners = owners.ToList();
                ownersResetEvent.Set();
                return tempOwners;
            }
            private set
            {
                ownersResetEvent.WaitOne();
                owners = value.ToList();
                ownersResetEvent.Set();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Owners)));
            }
        }    
        private async void Initialize()
        {
            Owners = await LoadFileAsync();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Owners));
        }
    }
