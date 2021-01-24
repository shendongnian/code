    public class MultiplexViewModel : INotifyPropertyChanged
    {
        private const string NoName = "(no name)";
        private bool isActive;
        private bool isActiveChanging;
        private string name;
        private readonly MultiPlexModel multiPlexModel;
        private readonly SynchronizationContext synchronizationContext;
        public MultiplexViewModel()
        {
            multiPlexModel = new MultiPlexModel();
            synchronizationContext = SynchronizationContext.Current;
            var bindingProperties = new[]
            {
                nameof(IsActive),
                nameof(IsActiveChanging)
            };
            var setNewNameBindings = new RelayCommandBindings()
            {
                Execute = async (obj) => await multiPlexModel.StartMultiplexModelAsync(obj.ToString()),
                CanExecuteChecks = new List<Predicate<object>>
                {
                    (obj) => IsValidName(obj?.ToString()),
                    (obj) => IsActive == false,
                    (obj) => IsActiveChanging == false
                },
                BindingModel = this,
                BindingProperties = bindingProperties
            };
            var stopMultiplexBindings = new RelayCommandBindings()
            {
                Execute = async (obj) => await multiPlexModel.StopMultiplexModelAsync(),
                CanExecuteChecks = new List<Predicate<object>>
                {
                    (obj) => IsActive == true,
                    (obj) => IsActiveChanging == false
                },
                BindingModel = this,
                BindingProperties = bindingProperties
            };
            SetNewNameCommand = new RelayCommand(setNewNameBindings);
            StopMultiplexCommand = new RelayCommand(stopMultiplexBindings);
            multiPlexModel.PropertyChanged += (s, e) => GetType().GetProperties().Where(p => p.Name == e.PropertyName).FirstOrDefault()?.SetValue(this, multiPlexModel.GetType().GetProperty(e.PropertyName).GetValue(multiPlexModel));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propertyName = "") => synchronizationContext.Post((o) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)), null);
        public bool IsActive
        {
            get { return isActive; }
            private set
            {
                isActive = value;
                Notify();
            }
        }
        public bool IsActiveChanging
        {
            get { return isActiveChanging; }
            private set
            {
                isActiveChanging = value;
                Notify();
            }
        }
        public string Name
        {
            get { return string.IsNullOrEmpty(name) ? NoName : name; }
            private set
            {
                name = value;
                Notify();
            }
        }
        private bool IsValidName(string name) => (name?.StartsWith("@")).GetValueOrDefault();
        public RelayCommand SetNewNameCommand { get; private set; }
        public RelayCommand StopMultiplexCommand { get; private set; }
    }
