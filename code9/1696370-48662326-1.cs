    namespace VM
    {
        public class MainViewModel : BaseViewModel
        {
            public MainViewModel()
            {
                ProfilesCollection = new List<Profile>();
                for (int i = 0; i < 100; i++)
                {
                    ProfilesCollection.Add(new Profile() {Name = $"Name {i}"});
                }
            }
            private List<Profile> profilesCollection;   
            public List<Profile> ProfilesCollection
            {
                get { return profilesCollection; }
                set { profilesCollection = value; OnPropertyChanged(); }
            }
        }
    }  
