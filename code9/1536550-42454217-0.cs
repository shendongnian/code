    public Dictionary<TKey2, ReferenceTypedValues> SyncronizationExample1(Dictionary<TKey, Dictionary<TKey2, ReferenceTypedValues>> outerDictionary, TKey newKey)
    {
        Dictionary<TKey2, ReferenceTypedValues> innerDictionary = null;
    
        lock (outerDictionary)
        {
            // No need to add a new innerDictionary if it already exists
            if (!outerDictionary.TryGetValue(newKey, out innerDictionary))
            {
                innerDictionary = new Dictionary<TKey2, ReferenceTypedValues>();
                outerDictionary.Add(newKey, innerDictionary);
            }    
        }
    
        // Found the inner dictionary, but might be racing with another thread
        // that also just found it. Lock and check whether it needs populating
        lock (innerDictionary)
        {
            if (innerDictionary.Count == 0)
            {
                this.PopulateInnerDictionary(innerDictionary);
            }
        }
        return innerDictionary;
    }
