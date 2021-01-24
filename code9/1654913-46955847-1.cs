    public class SelectionWrapper<T> : DynamicObject, INotifyPropertyChanged, ICustomTypeDescriptor
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }
        private T _Model;
        public T Model
        {
            get { return _Model; }
            set { SetProperty(ref _Model, value); }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (Model != null)
            {
                var prop = typeof(T).GetProperty(binder.Name);
                // indexer member will need parameters... not bothering with it
                if (prop != null && prop.CanRead && prop.GetMethod != null && prop.GetMethod.GetParameters().Length == 0)
                {
                    result = prop.GetValue(Model);
                    return true;
                }
            }
            return base.TryGetMember(binder, out result);
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            // not returning the Model property here
            return typeof(T).GetProperties().Select(x => x.Name).Concat(new[] { "IsSelected" });
        }
        public PropertyDescriptorCollection GetProperties()
        {
            var props = GetDynamicMemberNames();
            return new PropertyDescriptorCollection(props.Select(x => new DynamicPropertyDescriptor(x, GetType(), typeof(T))).ToArray());
        }
        // some INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent([CallerMemberName]string prop = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(prop));
        }
        protected bool SetProperty<T2>(ref T2 store, T2 value, [CallerMemberName]string prop = null)
        {
            if (!object.Equals(store, value))
            {
                store = value;
                RaisePropertyChangedEvent(prop);
                return true;
            }
            return false;
        }
        // ... A long list of interface method implementations that just throw NotImplementedException for the example
    }
