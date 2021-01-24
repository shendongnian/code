    public class DataErrorInfoWrapper : DynamicObject, IDataErrorInfo, INotifyPropertyChanged
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> Properties = new ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>>();
        private readonly Dictionary<string, PropertyInfo> _typeProperties;
        private readonly Func<string, string> _error;
        private readonly object _target;
        public string this[string columnName] => _error(columnName);
        public string Error { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public DataErrorInfoWrapper(object target, Func<string, string> error)
        {
            _error = error;
            _target = target;
            _typeProperties = Properties.GetOrAdd(_target.GetType(), t => t.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(i => i.SetMethod != null && i.GetMethod != null).ToDictionary(i => i.Name));
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (!_typeProperties.TryGetValue(binder.Name, out var property))
                return false;
            var getter = property.CreateGetter();
            result = getter.DynamicInvoke(_target);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!_typeProperties.TryGetValue(binder.Name, out var property))
                return false;
            var setter = property.CreateSetter();
            setter.DynamicInvoke(_target, value);
            RaisePropertyChanged(binder.Name);
            return true;
        }
        protected virtual bool SetProperty<TValue>(ref TValue storage, TValue value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TValue>.Default.Equals(storage, value))
                return false;
            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        protected virtual bool SetProperty<TValue>(ref TValue storage, TValue value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TValue>.Default.Equals(storage, value))
                return false;
            storage = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
