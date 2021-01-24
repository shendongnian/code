    using VM.Commands;
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
                RenameCommand = new TestCommand(renameCommandMethod, (o) => true);
            }
        void renameCommandMethod(object parameter)// to manipulate the colleciton you use the Commands which you already do but without the need for converters or any UI elements. Makes it much easier to handle.
        {
            string renameTo = parameter.ToString();
            foreach (var profile in ProfilesCollection)
            {
                profile.Name = renameTo;
            }
        }
        private List<Profile> profilesCollection;   
        public List<Profile> ProfilesCollection
        {
            get { return profilesCollection; }
            set { profilesCollection = value; OnPropertyChanged(); }
        }
        private ICommand renameCommand;
        public ICommand RenameCommand
        {
            get { return renameCommand; }
            set { renameCommand = value; }
        }  
