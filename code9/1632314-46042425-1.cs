    public class ViewModel
    {
        public ObservableCollection<ExpanderData> List { set; get; } = new ObservableCollection<ExpanderData>();
        private ICommand _buttonClickedCommand;
        public ICommand ButtonClickedCommand
        {
            get
            {
                if (_buttonClickedCommand == null)
                {
                    _buttonClickedCommand = new RelayCommand(p => ButtonClicked(p));
                }
                return _buttonClickedCommand;
            }
        }
    
        public void ButtonClicked(Object o)
        {
            var expanderData = (ExpanderData)o;
            var textThatYouWantedToHaveOnButtonClicked = expanderData.SomeText; 
        } 
    }
