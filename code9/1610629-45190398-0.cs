    public class Wrapper<T> : DynamicObject, INotifyPropertyChanged
    {
        readonly Dictionary<string, T> _dictionary;
        public Wrapper(Dictionary<string, T> dictionary)
        {
            _dictionary = dictionary;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            T value;
            if (!_dictionary.TryGetValue(binder.Name, out value))
            {
                value = default(T);
                _dictionary.Add(binder.Name, value);
            }
            result = value;
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = (T)value;
            OnPropertyChanged(binder.Name);
            return true;
        }
        ...
    }
