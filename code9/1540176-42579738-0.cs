    namespace Tabu.ViewModel
    {
      class TeamStatistic : INotifyPropertyChanged
      {
        public Team Team1 = new Team();
        public int TeamPoints
        {
            get { return Team1.TeamPoints; }
            set { Team1.TeamPoints = value; OnPropertyChanged("TeamPoints"); }
        }
        private ICommand _AddPoints;
        public ICommand AddPoints
        {
            get { return _AddPoints; }
            set { _AddPoints = value; }
        }
        public void Add_Points()
        {
            Team1.TeamPoints++;
        }
        public TeamStatistic ()
        {
            _AddPoinss = new RelayCommand(Add_Points);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] propsName)
        {
            if (PropertyChanged!=null)
            {
                foreach(string propName in propsName)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
