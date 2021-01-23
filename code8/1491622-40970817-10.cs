    public class TAEngineViewModel:IDisposable
    {
        private IList<IDisposable> _disposablesChildrenList = new List<IDisposable>();
        private readonly ObservableCollection<ItemWithName> _parameterList;
        public ObservableCollection<ItemWithName> CalcFilesList => _parameterList;
        public ObservableCollection<ItemWithName> ParameterFilesList => _parameterList;
        public TAEngineViewModel()
        {
            _parameterList = new ObservableCollection<ItemWithName>
            {
                new ItemWithName {Name = "AAAAAA"},
                new ItemWithName {Name = "BBBBBB"},
                new ItemWithName {Name = "CCCCCC"},
                new ItemWithName {Name = "DDDDDD"}
            };
            Subscribe(_parameterList);
        }
        private  void Subscribe(ObservableCollection<ItemWithName> parameterList)
        {
            foreach (var itemWithName in parameterList)
            {
                var onRightClickObservableSubscription = itemWithName.OnRightClickObservable.Subscribe(OnClick);
                var onDoubleClickObservableSubscription = itemWithName.OnDoubleClickObservable.Subscribe(OnDoubleClick);
                _disposablesChildrenList.Add(onDoubleClickObservableSubscription);
                _disposablesChildrenList.Add(onRightClickObservableSubscription);
            }
        }
        public void OnClick(IItemArguments args)
        {
            Debug.WriteLine($"{args.SpecificItemWithName.Name} evet {args.SpecificEventArgs.GetType().Name}");
        }
        public void OnDoubleClick(IItemArguments args )
        {
            Debug.WriteLine($"{args.SpecificItemWithName.Name} evet {args.SpecificEventArgs.GetType().Name}");
        }
        public void Dispose()
        {
            foreach (var disposable in _disposablesChildrenList)
            {
                disposable.Dispose();
            }
        }
    }
    public interface IItemArguments
    {
        ItemWithName SpecificItemWithName { get;}
        object SpecificEventArgs { get;}
    }
    public class ItemArguments : IItemArguments
    {
        public ItemArguments(ItemWithName item, object args)
        {
            SpecificItemWithName = item;
            SpecificEventArgs = args;
        }
        public ItemWithName SpecificItemWithName { get; }
        public object SpecificEventArgs { get; }
    }
    public class ItemWithName:BaseObservableObject
    {
        private string _name;
        private Subject<IItemArguments> _onDoubleClick = new Subject<IItemArguments>();
        private Subject<IItemArguments> _onClick = new Subject<IItemArguments>();
        public IObservable<IItemArguments> OnDoubleClickObservable;
        public IObservable<IItemArguments> OnRightClickObservable;
        public ItemWithName()
        {
            OnDoubleClickObservable = _onDoubleClick.AsObservable();
            OnRightClickObservable = _onClick.AsObservable();
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
            _onClick.OnNext(new ItemArguments(this, args));
        }
        public void OnDoubleClick(object args)
        {
            _onDoubleClick.OnNext(new ItemArguments(this, args));
        }
    }
