    public class TeaConfigurationViewModel : BaseViewModel
    {
        public TeaConfigurationViewModel()
        {
            _TeaNames = new string[]
            {
                "Lipton",
                "Generic",
                "Misc",
            };
        }
        private IEnumerable<string> _TeaNames;
        public IEnumerable<string> TeaNames
        {
            get { return _TeaNames; }
        }
        private string _SelectedTea;
        public string SelectedTea
        {
            get { return _SelectedTea; }
            set { SetProperty(ref _SelectedTea, value); }
        }
        private bool _IsHotTea;
        public bool IsHotTea
        {
            get { return _IsHotTea; }
            set { SetProperty(ref _IsHotTea, value); }
        }
        private bool _WithMilk;
        public bool WithMilk
        {
            get { return _WithMilk; }
            set { SetProperty(ref _WithMilk, value); }
        }
        private bool _WithLemon;
        public bool WithLemon
        {
            get { return _WithLemon; }
            set { SetProperty(ref _WithLemon, value); }
        }
        private bool _WithSyrup;
        public bool WithSyrup
        {
            get { return _WithSyrup; }
            set { SetProperty(ref _WithSyrup, value); }
        }
    }
