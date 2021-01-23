    public class GameControllerViewModel : INotifyPropertyChanged
    {
        private Team _currentTeam;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public GameControllerViewModel(IEnumerable<Team> teams)
        {
            Teams = teams;
        }
    
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public Team CurrentTeam
        {
            get { return _currentTeam; }
            set
            {
                if (value != _currentTeam)
                {
                    _currentTeam = value;
    
                    OnPropertyChanged();
                }
            }
        }
    
        public IEnumerable<Team> Teams { get; private set; }
    }
    
    public class Team
    {
        public string Name { get; set; }
    }
