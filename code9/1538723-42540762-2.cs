    public class MainWindowViewModel
    {
        public MainWindow window { get; set; }
        public ObservableCollectionWithDeletionControl<Person> People { get; set; } = new ObservableCollectionWithDeletionControl<Person>();
        public MainWindowViewModel()
        {
            People.DeletionDenied += People_DeletionDenied;
        }
        private void People_DeletionDenied(object sender, int indexOfDeniedDeletion)
        {
            Person personSavedFromDeletion = People[indexOfDeniedDeletion];
            window.displayDeniedDeletion(personSavedFromDeletion.Name);
        }
    }
