    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public DateTimeModel DateTimeModel;
        [DependsOn(nameof(DateTimeModel))]
        public DateTime CurrentDateTime => DateTimeModel.CurrentDateTime;
        public MainViewModel()
        {
            DateTimeModel = new DateTimeModel();
            DateTimeModel.PropertyChanged += (s, e) =>
            {
                Debug.WriteLine("DateTime PropertyChanged");
                this.RaisePropertyChanged(nameof(CurrentDateTime)); //<---
            };
        }
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
