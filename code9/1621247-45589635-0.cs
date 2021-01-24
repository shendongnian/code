    public class ViewModel
    {
        private ObservableCollection<MatchItemViewModel> _ListItems = new ObservableCollection<MatchItemViewModel>();
        public ObservableCollection<MatchItemViewModel> ListItems
        {
            get { return _ListItems; }
        }
        private ObservableCollection<string> _ComboboxItems = new ObservableCollection<string>();
        public ObservableCollection<string> ComboboxItems
        {
            get { return _ComboboxItems; }
        }
    }
    public class MatchItemViewModel : INotifyPropertyChanged
    {
        private string _SomeText;
        public string SomeText
        {
            get { return _SomeText; }
            set { _SomeText = value; RaisePropertyChangedEvent(); }
        }
        private string _SelectedFromCombobox;
        public string SelectedFromCombobox
        {
            get { return _SelectedFromCombobox; }
            set { _SelectedFromCombobox = value; RaisePropertyChangedEvent(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent([CallerMemberName]string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
    }
