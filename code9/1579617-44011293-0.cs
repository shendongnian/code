    public class ViewModelMain : ViewModelBase
    {
        public ViewModelMain()
        {
            Items = new ObservableCollection<MemEntity> {
                new MemEntity { Word1 = "a", Correct = 3, Incorrect = 1 },
                new MemEntity { Word1 = "b", Correct = 1, Incorrect = 0 },
                new MemEntity { Word1 = "c", Correct = 30, Incorrect = 5 }
            };
        }
        public ICommand Answer
        {
            get
            {
                if (_answer == null)
                {
                    _answer = new RelayCommand(
                        p => true,
                        p => AnalyzeAnswer());
                }
                return _answer;
            }
        }
        private ICommand _answer;
        public void AnalyzeAnswer()
        {
            //use SelectedItem and Text in this method,
            //you don't need to pass them as parameters
        }
        public string Text { get; set; }
        public ObservableCollection<MemEntity> Items { get; set; }
        public MemEntity SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                Console.Beep(1000, 200);
                _SelectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        private MemEntity _SelectedItem;
    }
