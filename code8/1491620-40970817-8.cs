    public class TAEngineViewModel:IOnClickSupport
    {
        private readonly ObservableCollection<ItemWithName> _parameterList;
        public ObservableCollection<ItemWithName> CalcFilesList => _parameterList;
        public ObservableCollection<ItemWithName> ParameterFilesList => _parameterList;
        public TAEngineViewModel()
        {
            _parameterList = new ObservableCollection<ItemWithName>
            {
                new ItemWithName(this) {Name = "AAAAAA"},
                new ItemWithName(this) {Name = "BBBBBB"},
                new ItemWithName(this) {Name = "CCCCCC"},
                new ItemWithName(this) {Name = "DDDDDD"}
            };
        }
        public void OnClick(object args)
        {
            
        }
        public void OnDoubleClick(object args )
        {
            
        }
    }
    public interface IOnClickSupport
    {
        void OnClick(object args);
        void OnDoubleClick(object args);
    }
    public class ItemWithName:BaseObservableObject
    {
        private readonly IOnClickSupport _support;
        private string _name;
        public ItemWithName(IOnClickSupport support)
        {
            _support = support;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public void OnClick(object args)
        {
            _support.OnClick(args);
        }
        public void OnDoubleClick(object args)
        {
            _support.OnDoubleClick(args);
        }
    }
