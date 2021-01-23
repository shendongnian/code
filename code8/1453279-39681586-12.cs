    public class ViewModel
    {
        private readonly LoadService _LoadService;
        private readonly SaveService _SaveService;
 
        private ObservableCollection<ConfigurationItemProperties> _Items
        public ObservableCollection<ConfigurationItemProperties> Items 
        { 
            get { return _Items; } 
            set
            {
                _Items = value;
                RaisePropertyChanged(nameOf(Items));
            } 
        }
        
        public ICommand Save { get; set; }
        public ICommand Load { get; set; }
        public ViewModel(LoadService loadService, SaveService saveService)
        {
            _LoadService = loadService;
            _SaveService = saveService;
            // Create command instance for Save
            // Create command instance for Load
      
            var itemsList = _LoadService.Load();
            Items = new ObservableCollection(itemsList);
        } 
    }
 
