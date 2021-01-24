    public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
        // this will be called when you do myDict[index] (but not myDict[index] = something)
        if (indexes.Length != 1)
            throw new Exception("Only 1-dimensional indexer is supported");
        var index = indexes[0];
        // if our internal dictionary does not contain this key
        // return null
        if (!_dictionary.ContainsKey(index)) {
            result = null;
        }
        else {
            result = _dictionary[index];
        }
        return true;
    }
