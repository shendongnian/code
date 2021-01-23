    public class ViewModel
    {
        private readonly LoadService _LoadService;
        private readonly SaveService _SaveService;
 
        //Here you can use your"Facade" implementation
        private ObservableCollection<ConfigurationItemPropertiesFacade> _Items
        public ObservableCollection<ConfigurationItemPropertiesFacade> Items 
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
            var facadeItems = itemsList.Select(item => new ConfigurationItemPropertiesFacade(item));
            Items = new ObservableCollection(facadeItems);
        } 
    }
 
