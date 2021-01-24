    public class DynamicData : DynamicObject, IData
    {
        private class FakeGetMemberBinder : GetMemberBinder
        {
            public FakeGetMemberBinder(string name, bool ignoreCase) : base(name, ignoreCase) { }
            public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
            {
                throw new NotSupportedException();
            }
        }
        public string id { get; set; }
        public string name { get; set; }
        public string price => GetMemberWithSufix();
        public string CurrencySufix { get; set; }
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }
        public override IEnumerable<string> GetDynamicMemberNames() => _dictionary.Keys;
        private string GetMemberWithSufix([CallerMemberName] string callerMemberName = null)
        {
            var getBinder = new FakeGetMemberBinder(callerMemberName + "_" + CurrencySufix, false);
            object value;
            if (TryGetMember(getBinder, out value))
                return value?.ToString();
            throw new KeyNotFoundException();
        }
    }
