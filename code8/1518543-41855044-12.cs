    public class ViewModel : Notifier
    {
        public ViewModel()
        {
            Groups = new ObservableCollection<GroupingModel>
            {
                new GroupingModel {
                    Header = "First Group",
                    Wells = new List<WVWellModel> {
                        new WVWellModel() { WellName = "First Well" },
                        new WVWellModel() { WellName = "Second Well" },
                        new WVWellModel() { WellName = "Third Well" },
                    }
                },
                new GroupingModel {
                    Header = "Second Group",
                    Wells = new List<WVWellModel> {
                        new WVWellModel() { WellName = "Third Well" },
                        new WVWellModel() { WellName = "Fourth Well" },
                        new WVWellModel() { WellName = "Fifth Well" },
                    }
                }
            };
        }
        #region Groups Property
        private ObservableCollection<GroupingModel> _groups = new ObservableCollection<GroupingModel>();
        public ObservableCollection<GroupingModel> Groups
        {
            get { return _groups; }
            set
            {
                if (value != _groups)
                {
                    _groups = value;
                    OnPropertyChanged(nameof(Groups));
                }
            }
        }
        #endregion Groups Property
    }
