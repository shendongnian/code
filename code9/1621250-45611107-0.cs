      public class QuestionMatchesModel :BaseModel
    {
        public ObservableCollection<MatchOptions> Answers { get; set; }
        private MatchOptions _selected;
        public MatchOptions Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                RaisePropertyChanged("Selection");
            }
        }
    }
    public class MatchOptions : BaseModel
    {
        public long ResponseId { get; set; }
        public long MatchId { get; set; }
        public string Answer { get; set; }
    }
