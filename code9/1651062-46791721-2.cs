    class MyExpando : DynamicObject
        {
            private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var name = binder.Name.ToLower();
                result = _dictionary.ContainsKey(name) ? _dictionary[name] : null;
                return true;
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                _dictionary[binder.Name.ToLower()] = value;
                return true;
            }
        }
