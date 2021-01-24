    public class DynamicDictionary : DynamicObject {
        private readonly Dictionary<object, object> _dictionary;
        public DynamicDictionary() {
            _dictionary = new Dictionary<object, object>();
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
            // this will be called when you do myDict[index] (but not myDict[index] = something)
            if (indexes.Length != 1)
                throw new Exception("Only 1-dimensional indexer is supported");
            var index = indexes[0];
            // if our internal dictionary does not contain this key
            // - add new DynamicDictionary for that key and return that
            if (_dictionary.ContainsKey(index)) {
                _dictionary.Add(index, new DynamicDictionary());
            }
            result = _dictionary[index];
            return true;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
            // this will be called when you do myDict[index] = value
            if (indexes.Length != 1)
                throw new Exception("Only 1-dimensional indexer is supported");
            var index = indexes[0];
            // just set value
            _dictionary[index] = value;
            return true;
        }
    }
