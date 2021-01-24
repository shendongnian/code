    public class MyGameOverviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Grouping<string, UpComingGame>> _upcomingGamesGrouped;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Grouping<string, UpComingGame>> UpcomingGamesGrouped
        {
            get { return _upcomingGamesGrouped; }
            set
            {
                _upcomingGamesGrouped = value;
                OnPropertyChanged(); // comment this line to see what you have done wrong
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void LoadData()
        {
            var upcomingGames = new[]
            {
                new UpComingGame("Berlin", "Munich", "1000435", "Munich", "today"),
                new UpComingGame("Frankfurt", "Munich", "1000435", "Munich", "today"),
                new UpComingGame("Hamburg", "Munich", "1000435", "Munich", "today"),
                new UpComingGame("Gera", "Munich", "1000435", "Munich", "tomorrow"),
                new UpComingGame("Stauutgart", "Munich", "1000435", "Munich", "tomorrow"),
            };
            var sorted = from fixture in upcomingGames
                         orderby fixture.Date
                         group fixture by fixture.DateSort into fixtureGroup
                         select new Grouping<string, UpComingGame>(fixtureGroup.Key, fixtureGroup);
            UpcomingGamesGrouped = new ObservableCollection<Grouping<string, UpComingGame>>(sorted);
        }
    }
