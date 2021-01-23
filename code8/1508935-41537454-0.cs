    public class ActorViewModel : INotifyPropertyChanged
    {
        public ActorViewModel()
        {
            Actors = ActorRepository.ActorList();
        }
        public List<Actor> Actors { get; private set; }
        private Actor _selectedActor;
        public Actor SelectedActor
        {
            get { return _selectedActor; }
            set { _selectedActor = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
