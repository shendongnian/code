    internal class MainViewModel
    {
        private readonly Messenger eventAggregator1 = new Messenger();
        private readonly Messenger eventAggregator2 = new Messenger();
        public MainViewModel()
        {
            this.ParentViewModel1 = new ParentViewModel(this.eventAggregator1);
            this.ParentViewModel2 = new ParentViewModel(this.eventAggregator2);
        }
        public ParentViewModel ParentViewModel1 { get; }
        public ParentViewModel ParentViewModel2 { get; }
    }
    internal class ParentViewModel
    {
        public ParentViewModel(Messenger eventAggregator)
        {
            this.ButtonsViewModel = new ButtonsViewModel(eventAggregator);
            this.ResultViewModel = new ResultViewModel(eventAggregator);
        }
        public ButtonsViewModel ButtonsViewModel { get; } 
        public ResultViewModel ResultViewModel { get; }
    }
    internal class ButtonsViewModel
    {
        private readonly Messenger eventAggregator;
        public ButtonsViewModel(Messenger eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.StartCommand = new DelegateCommand(this.StartProcessing);
        }
        public DelegateCommand StartCommand { get; }
        private void StartProcessing()
        {
            this.eventAggregator.RaiseDoWork("test path");
        }
    }
    internal class ResultViewModel : ViewModelBase
    {
        private readonly Model model = new Model();
        private string textValue;
        public ResultViewModel(Messenger eventAggregator)
        {
            eventAggregator.DoWork += (sender, s) => this.DoWorkHandler(s);
        }
        public string TextValue
        {
            get { return this.textValue; }
            set { this.SetProperty(ref this.textValue, value); }
        }
        private void DoWorkHandler(string s)
        {
            var result = this.model.Process(s);
            this.TextValue = result;
        }
    }
