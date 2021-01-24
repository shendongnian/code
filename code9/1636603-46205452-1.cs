    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        // ... snip ...
        [DependsOn(nameof(DateTimeModel))]
        [DependsOn("DateTimeModel.CurrentDateTime")]
        public DateTime CurrentDateTime => DateTimeModel.CurrentDateTime;
    }
